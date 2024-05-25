using Microsoft.EntityFrameworkCore;
using SklepSportowy.Models;


namespace SklepSportowy.Persistance
{
    public class SklepDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public SklepDbContext(DbContextOptions<SklepDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
