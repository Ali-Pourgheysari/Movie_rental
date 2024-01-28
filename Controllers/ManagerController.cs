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
        private string _managerId;

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
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT DISTINCT [User].Name, [User].UserName, [User].Email, DelayCount 
                           FROM [User] 
                           JOIN Customer ON [User].Id = Customer.Id
                           JOIN Rentals ON Customer.Id = Rentals.CustomerId 
                           JOIN Inventories ON Rentals.InventoryId = Inventories.Id 
                           JOIN Stores ON Inventories.StoreId = Stores.Id 
                           WHERE Stores.ManagerId = '{_managerId}'";
            
            return View(executeQuery.GetExecuteQuery<CustomerInfo>(query));
        }

        public async Task<IActionResult> AllRentals()
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            // Active condition is checked in the view
            var query = $@"SELECT
                            r.* 
                        FROM
                            Rentals r
                        JOIN
                            Inventories i ON r.InventoryId = i.Id
                        JOIN
                            Stores s ON i.StoreId = s.Id
                        WHERE
                            s.ManagerId = '{_managerId}'";

            return View(executeQuery.GetExecuteQuery<Rental>(query));
        }

        [HttpPost]
        public async Task<IActionResult> AllRentals(DateTime RentalDate, DateTime ReturnDate, int Id)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Rentals SET RentalDate = '{RentalDate}', ReturnDate = '{ReturnDate}' WHERE Id = {Id}";
            executeQuery.PostExecuteQuery(query);
            return RedirectToAction("AllRentals");
        }

        public async Task<IActionResult> CheckReservation()
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
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
                            s.ManagerId = '{_managerId}'";
            var data = executeQuery.GetExecuteQuery<CheckReservation>(query);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> CheckReservation(int reservationId, int inventoryId, string customerId)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var deleteFromReservationquery = $@"DELETE FROM Reservations WHERE Id = {reservationId}";
            var addToRentalQuery = $@"INSERT INTO Rentals (RentalDate, InventoryId, CustomerId) VALUES (GETDATE(), {inventoryId}, '{customerId}')";
            executeQuery.PostExecuteQuery(deleteFromReservationquery);
            executeQuery.PostExecuteQuery(addToRentalQuery);
            return RedirectToAction("CheckReservation");
        }

        [HttpPost]
        public async Task<IActionResult> StoresDetails(string address, int id)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Stores SET Address = '{address}' WHERE Id = {id}";
            executeQuery.PostExecuteQuery(query);
            return RedirectToAction("StoresDetails");
        }

        public async Task<IActionResult> ChosenCustomer(string id, string storeId)
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

        public async Task<IActionResult> ChosenFilm(int id, string storeId)
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
            var query = $@"SELECT top(1)
                            C.name AS TopCategory,
                            F.Title AS TopFilm,
                            A.FirstName AS FirstName,
	                        A.LastName AS LastName
                        FROM Rentals R
                        JOIN Inventories I ON R.InventoryId = I.Id
                        JOIN Films F ON I.FilmId = F.Id
                        JOIN FilmCategories FC ON F.Id = FC.FilmId
                        JOIN Categories C ON FC.CategoryId = C.Id
                        JOIN FilmActors FA ON F.Id = FA.FilmId
                        JOIN Actors A ON FA.ActorId = A.Id
                        WHERE I.StoreId = '1'
                        GROUP BY C.name, F.Title, A.FirstName, A.LastName
                        ORDER BY COUNT(*) DESC";

            return View(executeQuery.GetExecuteQuery<TopSellerModel>(query));
        }
    }
}
