using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_rental.Data;
using Movie_rental.Entities;
using Movie_rental.Migrations;
using Movie_rental.Models;
using System.Data.SqlClient;
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
            List<CustomerInfo> customers = new List<CustomerInfo>();
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var customer = new CustomerInfo();
                        foreach (var property in customer.GetType().GetProperties())
                        {
                            var value = result[property.Name];
                            if (value != DBNull.Value)
                            {
                                property.SetValue(customer, value);
                            }
                        }
                        customers.Add(customer);
                    }
                }
            }
            return View(customers);
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
            List<RentalDetails> rentalDetails = new List<RentalDetails>();
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var rentalDetail = new RentalDetails();
                        foreach (var property in rentalDetail.GetType().GetProperties())
                        {
                            var value = result[property.Name];
                            if (value != DBNull.Value)
                            {
                                property.SetValue(rentalDetail, value);
                            }
                        }
                        rentalDetails.Add(rentalDetail);
                    }
                }
                return View(rentalDetails);
            }
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

            List<Rental> AllRentals = new List<Rental>();
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var activeRental = new Rental();
                        foreach (var property in activeRental.GetType().GetProperties())
                        {
                            try
                            {
                                var value = result[property.Name];
                                if (value != DBNull.Value)
                                {
                                    property.SetValue(activeRental, value);
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        AllRentals.Add(activeRental);
                    }
                }
            }
            return View(AllRentals);
        }

        [HttpPost]
        public async Task<IActionResult> AllRentals(DateTime RentalDate, DateTime ReturnDate, int Id)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Rentals SET RentalDate = '{RentalDate}', ReturnDate = '{ReturnDate}' WHERE Id = {Id}";
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
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

            List<CheckReservation> reservations = new List<CheckReservation>();
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                _dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var reservation = new CheckReservation();
                        foreach (var property in reservation.GetType().GetProperties())
                        {
                            var value = result[property.Name];
                            if (value != DBNull.Value)
                            {
                                property.SetValue(reservation, value);
                            }
                        }
                        reservations.Add(reservation);
                    }
                }
            }
            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> CheckReservation(int reservationId, int inventoryId, string customerId)
        {
            _managerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var deleteFromReservationquery = $@"DELETE FROM Reservations WHERE Id = {reservationId}";
            var addToRentalQuery = $@"INSERT INTO Rentals (RentalDate, InventoryId, CustomerId) VALUES (GETDATE(), {inventoryId}, '{customerId}')";
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = deleteFromReservationquery;
                _dbContext.Database.OpenConnection();
                command.ExecuteNonQuery();
                command.CommandText = addToRentalQuery;
                command.ExecuteNonQuery();
            }
            return RedirectToAction("CheckReservation");
        }
    }
}
