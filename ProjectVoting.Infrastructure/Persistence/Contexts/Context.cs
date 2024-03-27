using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectVoting.Infrastructure.Persistence.Models;
using System.Diagnostics.CodeAnalysis;

namespace ProjectVoting.Infrastructure.Persistence.Contexts
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        // Source: https://stackoverflow.com/questions/56686093/unable-to-create-an-object-of-type-dbcontext
        // I mean, god damn! Couldn't they make it less obvious? What were they thinking?
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}