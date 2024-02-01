using Microsoft.AspNetCore.Authorization;
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
        private int _limitOfActiveMocties;

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
            _limitOfActiveMocties = 3;
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
                                    UPDATE Customer
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

            var nOfActiveAndReserveForCustomer = $@"WITH ActiveMovies AS (
                                                    SELECT COUNT(*) AS NumberOfActiveMovies
                                                    FROM Inventories I
                                                    JOIN Rentals R ON I.Id = R.InventoryId
                                                    WHERE I.StoreId = '{id}'
                                                    AND R.CustomerId = '{customerId}' 
                                                    AND (R.ReturnDate IS NULL OR R.ReturnDate > GETDATE())
                                                ),
                                                ReservedMovies AS (
                                                    SELECT COUNT(*) AS NumberOfReservedMovies
                                                    FROM Reservations RES
                                                    JOIN Inventories I ON RES.InventoryId = I.Id
                                                    WHERE I.StoreId = '{id}'
                                                    AND RES.CustomerId = '{customerId}')

                                                SELECT NumberOfActiveMovies + NumberOfReservedMovies AS TotalMovies
                                                FROM ActiveMovies, ReservedMovies;";

            var NumberOfActiveMovies = executeQuery.GetExecuteQuery<StoreDetailsModel>(nOfActiveAndReserveForCustomer).FirstOrDefault();
            if(NumberOfActiveMovies.TotalMovies >= _limitOfActiveMocties)
            {
                ViewData["ShowAlert"] = true;
                ViewData["AlertMessage"] = $"You have {_limitOfActiveMocties} or more active and reserved movies. You can't make a reservation.";
            }
            var customer = executeQuery.GetExecuteQuery<Customer>(delayCountQuery).FirstOrDefault();
            if (customer.DelayCount > _customerDelayCount)
            {
                ViewData["ShowAlert"] = true;
                ViewData["AlertMessage"] = $"You have more than {_customerDelayCount} delays. You can't make a reservation.";
            }

            //Available copies = Total copies - Rented copies - Reserved copies
            var query = $@"SELECT F.Id AS FilmId, F.Title AS FilmTitle, MAX(I.id) AS InventoryId,
                          (
                            SELECT COUNT(*)                            
                            FROM Inventories I2
                            WHERE I2.FilmId = F.Id
                              AND I2.StoreId = S.Id
                          ) - (
                            SELECT COUNT(*)
                            FROM Rentals R
							JOIN Inventories INV ON R.InventoryId = INV.Id
                            WHERE INV.StoreId = S.Id AND INV.FilmId = F.Id
                              AND (R.ReturnDate IS NULL OR R.ReturnDate > GETDATE())
                          ) - (
                            SELECT COUNT(*)
                            FROM Reservations RES
                            JOIN Inventories INV ON RES.InventoryId = INV.Id
                            WHERE INV.StoreId = S.Id AND INV.FilmId = F.Id
                          ) AS AvailableCopies
                        FROM Films F
                        JOIN Inventories I ON F.Id = I.FilmId
                        JOIN Stores S ON I.StoreId = S.Id
						LEFT JOIN Rentals R ON R.InventoryId = I.Id
                        WHERE S.id = '{id}' 
						AND I.Id NOT IN ( SELECT I.Id FROM Inventories I
							JOIN Stores S ON I.StoreId = S.Id
							JOIN Rentals R ON R.InventoryId = I.Id
							WHERE S.id = '{id}' AND (R.ReturnDate IS NULL OR R.ReturnDate > GETDATE())
						)
						GROUP BY F.Id, F.Title, S.Id";

            return View(executeQuery.GetExecuteQuery<ReservationModel>(query));
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
