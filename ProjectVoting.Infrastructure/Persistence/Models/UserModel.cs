using Microsoft.AspNetCore.Identity;

namespace ProjectVoting.Infrastructure.Persistence.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
