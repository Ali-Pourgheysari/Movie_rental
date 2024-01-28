﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_rental.Entities;
using Movie_rental.Models;
using Movie_rental.Services;
using System.Data;

namespace Movie_rental.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private ExecuteQuery executeQuery;
        private UserManager<User> userManager;
        private int _delayLimit;
        private int _costPerDay;
        private int _penalty;
        private int _customerDelayCount;

        public CustomerController(
        ExecuteQuery executeQuery,
        UserManager<User> userManager)
        {
            this.executeQuery = executeQuery;
            this.userManager = userManager;
            _delayLimit = 14;
            _costPerDay = 2;
            _penalty = 3;
            _customerDelayCount = 10;
        }
        [HttpGet]
        public async Task<IActionResult> RentalHistory()
        {
            var customerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"SELECT
                            f.Id AS FilmId,
                            f.Title,
	                        r.CustomerId,
	                        r.RentalDate,
                            r.ReturnDate,
	                        r.Id AS RentalId,
                            r.Score AS MyScore,
	                        {_delayLimit} - DATEDIFF(day, r.RentalDate, GETDATE()) AS DaysLeftToReturn
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
                        GROUP BY f.Id, f.Title, r.CustomerId, r.RentalDate, r.ReturnDate, r.Id, r.Score";

            return View(executeQuery.GetExecuteQuery<RentalDetails>(query));
        }

        [HttpPost]
        public async Task<IActionResult> RentalHistory(int rentalId, double score)
        {
            var customerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;
            var query = $@"UPDATE Rentals
                            SET Score = '{score}'
                            WHERE Id = '{rentalId}' AND CustomerId = '{customerId}'";

            executeQuery.PostExecuteQuery(query);

            var returnDateQuery = $@"UPDATE Rentals
                            SET ReturnDate = GETDATE()
                            WHERE Id = '{rentalId}'";

            executeQuery.PostExecuteQuery(returnDateQuery);

            // Update Payments
            var paymentQuery = $@"
                                DECLARE @RentalCost INT;

                                SELECT @RentalCost = 
                                    CASE
                                        WHEN DATEDIFF(DAY, RentalDate, ReturnDate) < {_delayLimit} THEN
                                            (DATEDIFF(DAY, RentalDate, ReturnDate) * {_costPerDay})
                                        ELSE
                                            ((DATEDIFF(DAY, RentalDate, ReturnDate) * {_costPerDay})
                                            + (DATEDIFF(DAY, RentalDate, ReturnDate) - {_delayLimit}) * {_penalty})
                                    END

                                FROM Rentals
                                WHERE Id = {rentalId};

                                INSERT INTO Payments (CustomerId, RentalId, Amount)
                                VALUES ('{customerId}', '{rentalId}', @RentalCost);

                                IF @RentalCost > {_delayLimit * _costPerDay}
                                BEGIN
                                    UPDATE Customers
                                    SET DelayCount = DelayCount + 1
                                    WHERE Id = '{customerId}'
                                END";

            executeQuery.PostExecuteQuery(paymentQuery);
            return RedirectToAction("RentalHistory");

        }

        [HttpGet]
        public async Task<IActionResult> Reservation(int id)
        {

            var customerId = (await userManager.FindByEmailAsync(User.Identity.Name)).Id;

            var delayCountQuery = $@"SELECT DelayCount
                                FROM Customer
                                WHERE Id = '{customerId}'";

            var customer = executeQuery.GetExecuteQuery<Customer>(delayCountQuery).FirstOrDefault();
            if (customer.DelayCount > _customerDelayCount)
            {
                ViewData["ShowAlert"] = true;
                ViewData["AlertMessage"] = $"You have more than {_customerDelayCount} delays. You can't make a reservation.";
            }

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
