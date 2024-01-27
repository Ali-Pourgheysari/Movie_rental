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
        private string _managerId;

        public ManagerController(
            MovieRentalDbContext dbContext,
            UserManager<User> userManager)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
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
            //var title_NRentals = $@"SELECT f.Id AS FilmId, f.Title, COUNT(Rentals.Id) AS NumberOfRentals
            //                        FROM Inventories i
            //                        LEFT JOIN Rentals on i.Id = Rentals.InventoryId
            //                        JOIN Films f ON i.FilmId = f.Id
            //                        JOIN Stores s ON i.StoreId = s.id
            //                        WHERE s.ManagerId = '{_managerId}'
            //                        GROUP BY f.Id, f.title;";

            //var nCopies = $@"SELECT f.Id AS FilmId, COUNT(i.Id) AS FilmCopies
            //                    FROM Inventories i
            //                    JOIN Films f ON i.FilmId = f.Id
            //                    JOIN Stores s ON i.StoreId = s.id
            //                    WHERE s.ManagerId = '{_managerId}'
            //                    GROUP BY f.Id, f.title, s.Id;";

            //var avgScore = $@"select FilmId, AVG(Score) as AvgScore from 
            //                    Films join Inventories on Films.Id = Inventories.FilmId
            //                    left JOIN Rentals ON Rentals.InventoryId = Inventories.Id 
            //                    JOIN Stores ON Inventories.StoreId = Stores.Id 
            //                    where ManagerId = '{_managerId}'
            //                    group by FilmId";

            //var delayCount = $@"select FilmId, COUNT(*) As NumberOfDelays from 
            //                    Films join Inventories on Films.Id = Inventories.FilmId
            //                    JOIN Rentals ON Rentals.InventoryId = Inventories.Id 
            //                    JOIN Stores ON Inventories.StoreId = Stores.Id  
            //                    WHERE Stores.ManagerId = '{_managerId}' 
            //                    AND DATEDIFF(day, RentalDate, ReturnDate) > 14
            //                    group by FilmId, StoreId";

            var query = $@"SELECT
                            f.Id AS FilmId,
                            f.Title,
                            COUNT(r.Id) AS NumberOfRentals,
                            COUNT(i.Id) AS FilmCopies,
                            AVG(r.Score) AS AvgScore,
                            COUNT(CASE WHEN DATEDIFF(day, r.RentalDate, r.ReturnDate) > 14 THEN 1 END) AS NumberOfDelays
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
    }
}
