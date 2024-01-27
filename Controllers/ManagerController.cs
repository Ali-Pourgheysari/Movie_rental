using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_rental.Data;
using Movie_rental.Services;
using Movie_rental.Entities;
using Movie_rental.Migrations;
using Movie_rental.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Movie_rental.Controllers
{
    public class ManagerController : Controller
    {
        private readonly MovieRentalDbContext _dbContext;
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

        public async Task<IActionResult> RentalDetails()
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT
                            f.Id AS FilmId,
                            f.Title,
                            COUNT(r.Id) AS NumberOfRentals,
                            COUNT(i.Id) AS FilmCopies,
                            AVG(r.Score) AS AvgScore,
                            COUNT(CASE WHEN DATEDIFF(day, r.RentalDate, r.ReturnDate) > {_delayLimit} THEN 1 END) AS NumberOfDelays
                        FROM
                            Inventories i
                        JOIN
                            Films f ON i.FilmId = f.Id
                        JOIN
                            Stores s ON i.StoreId = s.Id
                        LEFT JOIN
                            Rentals r ON i.Id = r.InventoryId
                        WHERE
                            s.ManagerId = '{_managerId}'
                        GROUP BY
                            f.Id, f.Title, S.Id;";
            
            return View(executeQuery.GetExecuteQuery<RentalDetails>(query));
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
	                        Films f ON f.Id = r.Id
                        JOIN
	                        [User] u ON u.Id = r.CustomerId
                        WHERE
                            s.ManagerId = '{_managerId}'";

            return View(executeQuery.GetExecuteQuery<CheckReservation>(query));
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

        public async Task<IActionResult> StoresDetails()
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT * FROM Stores WHERE ManagerId = '{_managerId}'";
            return View(executeQuery.GetExecuteQuery<Store>(query));
        }

        [HttpPost]
        public async Task<IActionResult> StoresDetails(string address, int id)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Stores SET Address = '{address}' WHERE Id = {id}";
            executeQuery.PostExecuteQuery(query);
            return RedirectToAction("StoresDetails");
        }

        public async Task<IActionResult> Films()
        {
            var query = $@"SELECT
                            f.Id AS FilmId,
                            f.Title AS FilmTitle,
	                        c.Id AS CategoryId,
	                        c.Name AS CategoryName,
                            AVG(r.Score) AS AvgScore
                        FROM
                            Inventories i
                        JOIN
                            Films f ON i.FilmId = f.Id
                        JOIN
	                        FilmCategories fc ON fc.FilmId = f.Id
                        JOIN
	                        Categories c ON c.Id = fc.CategoryId
                        JOIN
                            Rentals r ON i.Id = r.InventoryId
                        JOIN
                            Stores s ON i.StoreId = s.Id
                        GROUP BY
                            f.Id, f.Title, c.Name, c.Id
                        ORDER BY AvgScore desc;";

            return View("Films", executeQuery.GetExecuteQuery<FilmScoreCategory>(query));
        }

        public async Task<IActionResult> ChosenCategory(int id)
        {
            string query = $@"SELECT
                            f.Id AS FilmId,
                            f.Title AS FilmTitle,
                            c.Id AS CategoryId,
                            c.Name AS CategoryName,
                            AVG(r.Score) AS AvgScore
                        FROM
                            Inventories i
                        JOIN
                            Films f ON i.FilmId = f.Id
                        JOIN
                            FilmCategories fc ON fc.FilmId = f.Id
                        JOIN
                            Categories c ON c.Id = fc.CategoryId
                        JOIN
                            Rentals r ON i.Id = r.InventoryId
                        JOIN
                            Stores s ON i.StoreId = s.Id
                        WHERE
                            c.Id = {id}
                        GROUP BY
                            f.Id, f.Title, c.Name, c.Id
                        ORDER BY AvgScore desc;";

            return View("Films", executeQuery.GetExecuteQuery<FilmScoreCategory>(query));

        }

        public async Task<IActionResult> Search()
        {
            SearchModel data = new SearchModel();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            string actorName = $@"SELECT FirstName, LastName
                                FROM Actors
                                WHERE FirstName LIKE '%{search}%'
                                OR LastName LIKE '%{search}%';";

            string filmTitleYear = $@"SELECT Title, ReleaseYear
                                    FROM Films
                                    WHERE Title LIKE '%{search}%'
                                    OR ReleaseYear LIKE '%{search}%'; ";

            string categoryName = $@"SELECT Name
                                    FROM Categories
                                    WHERE Name LIKE '%{search}%';";

            string languageName = $@"SELECT Name
                                    FROM Languages
                                    WHERE Name LIKE '%{search}%';";

            List<Actor> actors = executeQuery.GetExecuteQuery<Actor>(actorName);
            List<Film> films = executeQuery.GetExecuteQuery<Film>(filmTitleYear);
            List<Category> categories = executeQuery.GetExecuteQuery<Category>(categoryName);
            List<Language> languages = executeQuery.GetExecuteQuery<Language>(languageName);

            SearchModel searchModel = new SearchModel 
            { 
                Actors = actors,
                Films = films, 
                Categories = categories,
                Languages = languages 
            };   

            return View(searchModel);
        }

        public async Task<IActionResult> PaymentDetails(int id)
        {
            var query = $@"SELECT p.Amount AS Amount, u.Name AS CustomerName, u.Id AS CustomerId, f.Id AS FilmId, f.Title AS FilmName, StoreId
                            FROM Payments P
                            JOIN Rentals R ON P.RentalId = R.Id
                            JOIN Inventories I ON R.InventoryId = I.Id
                            JOIN Films f ON f.Id = I.FilmId
                            JOIN [User] u ON u.Id = p.CustomerId
                            WHERE StoreId = {id}";

            return View(executeQuery.GetExecuteQuery<PaymentDetailsModel>(query));
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
