using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_rental.Data;
using Movie_rental.Entities;
using Movie_rental.Migrations;
using Movie_rental.Models;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Movie_rental.Controllers
{
    public class ManagerController : Controller
    {
        private readonly MovieRentalDbContext _dbContext;
        private readonly UserManager<User> userManager;
        private readonly int _delayLimit;
        private string _managerId;

        public ManagerController(
            MovieRentalDbContext dbContext,
            UserManager<User> userManager)
        {
            _dbContext = dbContext;
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
            
            return View(GetExecuteQuery<CustomerInfo>(query));
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
            
            return View(GetExecuteQuery<RentalDetails>(query));
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

            return View(GetExecuteQuery<Rental>(query));
        }

        [HttpPost]
        public async Task<IActionResult> AllRentals(DateTime RentalDate, DateTime ReturnDate, int Id)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Rentals SET RentalDate = '{RentalDate}', ReturnDate = '{ReturnDate}' WHERE Id = {Id}";
            PostExecuteQuery(query);
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

            return View(GetExecuteQuery<CheckReservation>(query));
        }

        [HttpPost]
        public async Task<IActionResult> CheckReservation(int reservationId, int inventoryId, string customerId)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var deleteFromReservationquery = $@"DELETE FROM Reservations WHERE Id = {reservationId}";
            var addToRentalQuery = $@"INSERT INTO Rentals (RentalDate, InventoryId, CustomerId) VALUES (GETDATE(), {inventoryId}, '{customerId}')";
            PostExecuteQuery(deleteFromReservationquery);
            PostExecuteQuery(addToRentalQuery);
            return RedirectToAction("CheckReservation");
        }

        public async Task<IActionResult> StoresDetails()
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT * FROM Stores WHERE ManagerId = '{_managerId}'";
            return View(GetExecuteQuery<Store>(query));
        }

        [HttpPost]
        public async Task<IActionResult> StoresDetails(string address, int id)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Stores SET Address = '{address}' WHERE Id = {id}";
            PostExecuteQuery(query);
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

            return View("Films", GetExecuteQuery<FilmScoreCategory>(query));
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

            return View("Films", GetExecuteQuery<FilmScoreCategory>(query));

        }

        public List<T> GetExecuteQuery<T>(string query) where T : new()
        {
            List<T> entities = new List<T>();
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var entity = new T();
                        foreach (var property in entity.GetType().GetProperties())
                        {
                            try
                            {
                                var value = result[property.Name];
                                if (value != DBNull.Value)
                                {
                                    property.SetValue(entity, value);
                                }
                            }
                            catch
                            {
                                continue;
                            }

                        }
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }

        private void PostExecuteQuery(string query)
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

    }
}
