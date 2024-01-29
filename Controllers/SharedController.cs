using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_rental.Data;
using Movie_rental.Entities;
using Movie_rental.Models;
using Movie_rental.Services;

namespace Movie_rental.Controllers
{
    [Authorize(Roles = "Manager, Customer")]
    public class SharedController : Controller
    {
        private readonly ExecuteQuery executeQuery;
        private readonly UserManager<User> userManager;
        private readonly int _delayLimit;
        private readonly int _customerDelayCount;

        public SharedController(
            ExecuteQuery executeQuery,
            UserManager<User> userManager)
        {
            this.executeQuery = executeQuery;
            this.userManager = userManager;
            _delayLimit = 14;
            _customerDelayCount = 10;
        }

        public async Task<IActionResult> StoresDetails()
        {
            var user = await userManager.GetUserAsync(User);
            var role = await userManager.GetRolesAsync(user);
            var query = $@"SELECT * FROM Stores";
            if (role[0] == "Manager")
            {
                query = $@"SELECT * FROM Stores WHERE ManagerId = '{user.Id}'";
                ViewBag.ManagerId = user.Id;
            }
            return View(executeQuery.GetExecuteQuery<Store>(query));
        }

        public IActionResult Films()
        {
            var user = userManager.GetUserAsync(User).Result;
            var userId = user.Id;
            var role = userManager.GetRolesAsync(user).Result[0];

            var query = GenerateBaseFilmQuery();

            if (role == "Manager")
            {
                query += $" WHERE s.ManagerId = '{userId}'";
            }

            query += " GROUP BY f.Id, f.Title, c.Name, c.Id, c.Name ORDER BY AvgScore DESC;";

            return View(executeQuery.GetExecuteQuery<RentalDetails>(query));
        }

        public IActionResult ChosenCategory(int id)
        {
            string query = GenerateBaseFilmQuery() + $" WHERE c.Id = {id} GROUP BY f.Id, f.Title, c.Name, c.Id ORDER BY AvgScore DESC;";

            return View("Films", executeQuery.GetExecuteQuery<RentalDetails>(query));
        }

        private string GenerateBaseFilmQuery()
        {
            return $@"SELECT
                f.Id AS FilmId,
                f.Title,
                c.Id AS CategoryId,
                c.Name AS CategoryName,
                AVG(r.Score) AS AvgScore,
                COUNT(r.Id) AS NumberOfRentals,
                COUNT(i.Id) AS FilmCopies,
                COUNT(CASE WHEN DATEDIFF(day, r.RentalDate, r.ReturnDate) > {_delayLimit} THEN 1 END) AS NumberOfDelays
            FROM
                Inventories i
            JOIN
                Films f ON i.FilmId = f.Id
            JOIN
                Stores s ON i.StoreId = s.Id
            LEFT JOIN
                FilmCategories fc ON fc.FilmId = f.Id
            LEFT JOIN
                Categories c ON c.Id = fc.CategoryId
            LEFT JOIN
                Rentals r ON i.Id = r.InventoryId";
        }

        public IActionResult Search()
        {
            SearchModel data = new SearchModel();
            return View(data);
        }

        [HttpPost]
        public IActionResult Search(string search)
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
                            JOIN [User] u ON u.Id = p.CustomerId";

            var user = (await userManager.GetUserAsync(User));
            var role = (await userManager.GetRolesAsync(user))[0];
            if (role == "Manager")
            {
                query += $@" WHERE StoreId = '{id}'";
            }
            else
            {
                query += $@" WHERE u.Id = '{user.Id}'";
            }

            return View(executeQuery.GetExecuteQuery<PaymentDetailsModel>(query));
        }
    }
}
