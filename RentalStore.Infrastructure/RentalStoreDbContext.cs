using Microsoft.EntityFrameworkCore;
using RentalStore.Domain.Models;

namespace RentalStore.Infrastructure
{
    public class RentalStoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RentalStoreDbContext(DbContextOptions<RentalStoreDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
