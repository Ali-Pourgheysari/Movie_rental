using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_rental.Entities;
using Movie_rental.Services;

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

    }
}
