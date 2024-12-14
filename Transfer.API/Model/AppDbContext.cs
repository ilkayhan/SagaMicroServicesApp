using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Transfer.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TransferRequest> TransferRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransferRequest>();

         

            base.OnModelCreating(modelBuilder); 
        }


    }

}
