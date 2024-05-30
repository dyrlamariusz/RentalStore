using Microsoft.EntityFrameworkCore;
using RentalStore.Domain.Models;

namespace RentalStore.Infrastructure
{
    public class RentalStoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // DO USUNIECIA
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Category> Categories { get; set; }

        public RentalStoreDbContext(DbContextOptions<RentalStoreDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationMap>()
                .HasKey(lm => lm.LocationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
