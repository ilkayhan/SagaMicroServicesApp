using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Account.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>();
            base.OnModelCreating(modelBuilder); 
        }


    }

}
