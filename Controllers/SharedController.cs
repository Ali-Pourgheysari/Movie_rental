using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_rental.Data;
using Movie_rental.Entities;
using Movie_rental.Services;

namespace Movie_rental.Controllers
{
    public class SharedController : Controller
    {
        private readonly ExecuteQuery executeQuery;
        private readonly UserManager<User> userManager;
        private readonly int _delayLimit;
        private string _managerId;

        public SharedController(
            ExecuteQuery executeQuery,
            UserManager<User> userManager)
        {
            this.executeQuery = executeQuery;
            this.userManager = userManager;
            _delayLimit = 14;
        }
    }
}
