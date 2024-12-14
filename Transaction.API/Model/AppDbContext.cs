using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Transaction.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TransactionRequest> TransactionRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionRequest>();

            base.OnModelCreating(modelBuilder); 
        }


    }

}
