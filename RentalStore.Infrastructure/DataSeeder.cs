using RentalStore.Domain.Models;

namespace RentalStore.Infrastructure
{
    public class DataSeeder
    {
        private readonly RentalStoreDbContext _dbContext;

        public DataSeeder(RentalStoreDbContext context)
        {
            this._dbContext = context;
        }

        public void Seed()
        {
            // _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())                     // DO USUNIECIA
                {
                    var products = new List<Product>
                    {
                        new Product()
                        {
                            Id = 1,
                            Name = "Kawa",
                            Description = "Mała czarna",
                            UnitPrice = 12,
                            CreatedAt = DateTime.Now.AddDays(-3),
                        },

                        new Product()
                        {
                            Id = 2,
                            Name = "Herbata",
                            Description = "English tea",
                            UnitPrice = 12,
                            CreatedAt = DateTime.Now.AddDays(-2),
                        },
                    };
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }                                                   //

                if (!_dbContext.Categories.Any())
                {
                    _dbContext.Categories.Add(new Category
                    {
                        CategoryName = "Narty zjazdowe",
                        Description = "Sprzęt narciarski"
                    });
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Equipments.Any())
                {
                    _dbContext.Equipments.Add(new Equipment
                    {
                        Name = "Narty zjazdowe damskie",
                        CategoryId = 1,
                        Brand = "ROSSIGNOL",
                        Model = "Nova 6",
                        Availability = true,
                        Condition = "Nowe",
                        Size = "Średnie"
                    });
                    _dbContext.SaveChanges();

                }

                if (!_dbContext.Feedbacks.Any())
                {
                    _dbContext.Feedbacks.Add(new Feedback
                    {
                        EquipmentId = 1, 
                        Rating = 5,
                        Comment = "Great equipment!",
                        FeedbackDate = DateTime.Now
                    });
                }

                if (!_dbContext.Rentals.Any())
                {
                    _dbContext.Rentals.Add(new Rental
                    {
                        EquipmentId = 1,
                        AgreementId = 1,
                        RentalDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(7),
                        Status = "Rented"
                    });
                    _dbContext.SaveChanges();

                }
            }
        }
    }
}
