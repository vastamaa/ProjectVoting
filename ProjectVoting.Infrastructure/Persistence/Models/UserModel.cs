using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace ProjectVoting.Infrastructure.Persistence.Models
{
    [ExcludeFromCodeCoverage]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
