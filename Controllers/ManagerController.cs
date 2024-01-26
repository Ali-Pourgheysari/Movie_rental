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
    }
}
