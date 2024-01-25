using Microsoft.AspNetCore.Identity;

namespace Movie_rental.Entities
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
    }
}