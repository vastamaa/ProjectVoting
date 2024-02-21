using Microsoft.EntityFrameworkCore;

namespace ProjectVoting.Infrastructure.Persistence.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

    }
}
