using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_rental.Data;
using Movie_rental.Services;
using Movie_rental.Entities;
using Movie_rental.Migrations;
using Movie_rental.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

namespace Movie_rental.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly ExecuteQuery executeQuery;
        private readonly UserManager<User> userManager;
        private readonly int _delayLimit;

        public ManagerController(
            ExecuteQuery executeQuery,
            UserManager<User> userManager)
        {
            this.executeQuery = executeQuery;
            this.userManager = userManager;
            _delayLimit = 14;
        }

        public async Task<IActionResult> AllCustomers()
        {
            var managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT DISTINCT [User].Name, [User].UserName, [User].Email, DelayCount 
                           FROM [User] 
                           JOIN Customer ON [User].Id = Customer.Id
                           JOIN Rentals ON Customer.Id = Rentals.CustomerId 
                           JOIN Inventories ON Rentals.InventoryId = Inventories.Id 
                           JOIN Stores ON Inventories.StoreId = Stores.Id 
                           WHERE Stores.ManagerId = '{managerId}'";
            
            return View(executeQuery.GetExecuteQuery<CustomerInfo>(query));
        }

        public async Task<IActionResult> AllRentals()
        {
            var managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            // Active condition is checked in the view
            var query = $@"SELECT
                            r.RentalDate,
                            r.ReturnDate,
                            r.Id,
                            r.Score,
                            r.InventoryId,
                            c.Name AS CustomerName
                        FROM
                            Rentals r
                        JOIN
                            Inventories i ON r.InventoryId = i.Id
                        JOIN
                            Stores s ON i.StoreId = s.Id
                        JOIN
                            [User] c ON r.CustomerId = c.Id
                        WHERE
                            s.ManagerId = '{managerId}'";

            return View(executeQuery.GetExecuteQuery<AllRentalsModel>(query));
        }

        [HttpPost]
        public async Task<IActionResult> AllRentals(DateTime RentalDate, DateTime ReturnDate, int Id)
        {
            var managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Rentals SET RentalDate = '{RentalDate}', ReturnDate = '{ReturnDate}' WHERE Id = {Id}";
            executeQuery.PostExecuteQuery(query);
            return RedirectToAction("AllRentals");
        }

        public async Task<IActionResult> CheckReservation()
        {
            var managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT
                            u.Id AS CustomerId, u.Name AS CustomerName, f.Title, r.Id AS ReservationId, i.Id AS InventoryId
                        FROM
                            Reservations r
                        JOIN
                            Inventories i ON r.InventoryId = i.Id
                        JOIN
                            Stores s ON i.StoreId = s.Id
                        JOIN
	                        Films f ON f.Id = i.FilmId
                        JOIN
	                        [User] u ON u.Id = r.CustomerId
                        WHERE
                            s.ManagerId = '{managerId}'";
            var data = executeQuery.GetExecuteQuery<CheckReservation>(query);
            return View(data);
        }

        [HttpPost]
        public IActionResult CheckReservation(int reservationId, int inventoryId, string customerId)
        {
            var deleteFromReservationquery = $@"DELETE FROM Reservations WHERE Id = {reservationId}";
            var addToRentalQuery = $@"INSERT INTO Rentals (RentalDate, InventoryId, CustomerId) VALUES (GETDATE(), {inventoryId}, '{customerId}')";
            if(inventoryId != 0)
            {
                executeQuery.PostExecuteQuery(addToRentalQuery);
            }
            executeQuery.PostExecuteQuery(deleteFromReservationquery);
            return RedirectToAction("CheckReservation");
        }

        [HttpPost]
        public async Task<IActionResult> StoresDetails(string name, string address, int id)
        {
            var managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Stores SET Address = '{address}', Name = '{name}' WHERE Id = {id}";
            executeQuery.PostExecuteQuery(query);
            return RedirectToAction(controllerName: "Shared", actionName: "StoresDetails");
        }

        public IActionResult ChosenCustomer(string id, string storeId)
        {
            var query = $@"SELECT p.Amount, u.Name AS CustomerName, u.Id AS CustomerId, f.Id AS FilmId, f.Title AS FilmName
                            FROM Payments P
                            JOIN Rentals R ON P.RentalId = R.Id
                            JOIN Inventories I ON R.InventoryId = I.Id
                            JOIN Films f ON f.Id = I.FilmId
                            JOIN [User] u ON u.Id = p.CustomerId
                            WHERE u.Id = '{id}' AND StoreId = '{storeId}'";

            return View("PaymentDetails", executeQuery.GetExecuteQuery<PaymentDetailsModel>(query));
        }

        public IActionResult ChosenFilm(int id, string storeId)
        {
            var query = $@"SELECT p.Amount, u.Name AS CustomerName, u.Id AS CustomerId, f.Id AS FilmId, f.Title AS FilmName
                            FROM Payments P
                            JOIN Rentals R ON P.RentalId = R.Id
                            JOIN Inventories I ON R.InventoryId = I.Id
                            JOIN Films f ON f.Id = I.FilmId
                            JOIN [User] u ON u.Id = p.CustomerId
                            WHERE f.Id = {id} AND StoreId = '{storeId}'";

            return View("PaymentDetails", executeQuery.GetExecuteQuery<PaymentDetailsModel>(query));
        }

        public async Task<IActionResult> TopSeller()
        {
            var managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var categoryQquery = $@"SELECT top(1)
                                    C.name AS TopCategory
                                FROM Rentals R
                                JOIN Inventories I ON R.InventoryId = I.Id
                                JOIN Films F ON I.FilmId = F.Id
                                JOIN FilmCategories FC ON F.Id = FC.FilmId
                                JOIN Categories C ON FC.CategoryId = C.Id
                                JOIN Stores S ON S.Id = I.StoreId
                                WHERE S.ManagerId = '{managerId}'
                                GROUP BY C.name
                                ORDER BY COUNT(*) DESC";

            var category = executeQuery.GetExecuteQuery<TopSellerModel>(categoryQquery).FirstOrDefault().TopCategory;
            var actorQuery = $@"SELECT top(1)
                                    A.LastName, 
                                    FirstName
                                FROM Rentals R
                                JOIN Inventories I ON R.InventoryId = I.Id
                                JOIN Films F ON I.FilmId = F.Id
                                JOIN FilmActors FA ON F.Id = FA.FilmId
                                JOIN Actors A ON FA.ActorId = A.Id
                                JOIN Stores S ON S.Id = I.StoreId
                                WHERE S.ManagerId = '{managerId}'
                                GROUP BY A.LastName, A.FirstName
                                ORDER BY COUNT(*) DESC";

            var actor = executeQuery.GetExecuteQuery<TopSellerModel>(actorQuery).FirstOrDefault();
            var filmQuery = $@"SELECT top(1)
                                    F.Title AS TopFilm
                                FROM Rentals R
                                JOIN Inventories I ON R.InventoryId = I.Id
                                JOIN Films F ON I.FilmId = F.Id
                                JOIN Stores S ON S.Id = I.StoreId
                                WHERE S.ManagerId = '{managerId}'
                                GROUP BY F.Title
                                ORDER BY COUNT(*) DESC";

            var film = executeQuery.GetExecuteQuery<TopSellerModel>(filmQuery).FirstOrDefault().TopFilm;
            var model = new TopSellerModel
            {
                TopCategory = category,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                TopFilm = film
            };
            var modelList = new List<TopSellerModel> { model };
            return View(modelList);
        }

        [HttpPost]
        public IActionResult AddStore(string managerId)
        {
            var query = $@"INSERT INTO Stores (Address, ManagerId) VALUES ('', '{managerId}')";
            executeQuery.PostExecuteQuery(query);
            return RedirectToAction("StoresDetails", "Shared");
        }
    }
}
