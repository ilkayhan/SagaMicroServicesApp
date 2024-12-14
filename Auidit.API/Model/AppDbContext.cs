using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace  Auidit.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AuditLog> AuditLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>();
            base.OnModelCreating(modelBuilder); 
        }
    }
}
