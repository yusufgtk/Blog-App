using Microsoft.AspNetCore.Identity;

namespace blogsite.webapp.Identity
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreateAt { get; set; }
    }
}