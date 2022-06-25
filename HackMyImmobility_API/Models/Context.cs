using Microsoft.EntityFrameworkCore;

namespace HackMyImmobility_API.Models
{
    public class Context : DbContext 
    {
        public Context(DbContextOptions<Context> options)
                : base(options)
        {
        }
        public DbSet<Flat> Flats { get; set; }

    }
}
