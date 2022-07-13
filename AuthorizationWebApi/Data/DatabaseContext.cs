using AuthorizationWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationWebApi.Data
{
    public class DatabaseContext : DbContext
    {
       
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
        }
    }
}
