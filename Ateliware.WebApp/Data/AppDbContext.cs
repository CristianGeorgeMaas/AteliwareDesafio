using Microsoft.EntityFrameworkCore;

using Ateliware.WebApp.Models;

namespace Ateliware.WebApp.Data
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Repos> Repositories { get; set; }
    }
}
