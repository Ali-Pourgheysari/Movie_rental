using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_rental.Entities;
using Movie_rental.Models;
using Movie_rental.Services;
using System.Data;

namespace Movie_rental.Controllers
{
    public class CustomerController : Controller
    {
        private ExecuteQuery executeQuery;
        private UserManager<User> userManager;
        private int _delayLimit;

        public CustomerController(
        ExecuteQuery executeQuery,
        UserManager<User> userManager)
        {
            this.executeQuery = executeQuery;
            this.userManager = userManager;
            _delayLimit = 14;
        }

        public async Task<IActionResult> RentalHistory()
        {
            var customerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT
                            f.Id AS FilmId,
                            f.Title,
	                        r.CustomerId,
                            r.ReturnDate
                        FROM
                            Inventories i
                        JOIN
                            Films f ON i.FilmId = f.Id
                        JOIN
                            Stores s ON i.StoreId = s.Id
                        LEFT JOIN
                            Rentals r ON i.Id = r.InventoryId
                        WHERE 
	                        r.CustomerId = '{customerId}'
                        GROUP BY f.Id, f.Title, r.CustomerId";


            return View(executeQuery.GetExecuteQuery<RentalDetails>(query));
        }

        public async Task<IActionResult> Reservation(int id)
        {
            //Available copies = Total copies - Rented copies - Reserved copies
            var query = $@"SELECT F.Id AS FilmId, F.Title AS FilmTitle, I.Id AS InventoryId,
                          (
                            SELECT COUNT(*)                            
                            FROM Inventories I2
                            WHERE I2.FilmId = F.Id
                              AND I2.StoreId = S.Id
                          ) - (
                            SELECT COUNT(*)
                            FROM Rentals R
                            WHERE R.InventoryId = I.Id
                              AND (R.ReturnDate IS NULL OR R.ReturnDate > GETDATE())
                          ) - (
                            SELECT COUNT(*)
                            FROM Reservations RES
                            WHERE RES.InventoryId = I.Id
                          ) AS AvailableCopies
                        FROM Films F
                        JOIN Inventories I ON F.Id = I.FilmId
                        JOIN Stores S ON I.StoreId = S.Id
                        WHERE S.id = '{id}'";

            var data = executeQuery.GetExecuteQuery<ReservationModel>(query);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Reservation(int inventoryId, int filmId)
        {
            var customerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            
            var query = $@"INSERT INTO Reservations (CustomerId, InventoryId)
                            VALUES ('{customerId}', '{inventoryId}')";

            executeQuery.PostExecuteQuery(query);
            return RedirectToAction("Reservation");
        }
    }
}
