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
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())   // do usuniecie w przyszlosci
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
                }                                                   

                if (!_dbContext.Categories.Any())
                {
                    var categories = new List<Category>
                    {
                        new Category { CategoryName = "Narty zjazdowe", Description = "Sprzęt narciarski" },
                        new Category { CategoryName = "Rower", Description = "Rower górski" }
                    };
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Equipments.Any())
                {
                    var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Narty zjazdowe");
                    if (category != null)
                    {
                        _dbContext.Equipments.Add(new Equipment
                        {
                            Name = "Narty zjazdowe damskie",
                            CategoryId = category.CategoryId,
                            Description = "Super szybkie narty damskie. Idealne w góry jak i w jezdzie po asfalcie. Nie przegap okazji! Tylko U NAS!",
                            Brand = "ROSSIGNOL",
                            Model = "Nova 6",
                            Availability = true,
                            Condition = "Nowe",
                            Size = "Średnie",
                            QuantityInStock=15,
                            PricePerDay = 200,
                            ImageUrl = "/images/no-image-icon.png"
                        });;
                    }

                    category = _dbContext.Categories.FirstOrDefault(c => c.CategoryName == "Rower");
                    if (category != null)
                    {
                        _dbContext.Equipments.Add(new Equipment
                        {
                            Name = "Rower górski",
                            CategoryId = category.CategoryId,
                            Description = "Wygodny i lekki rower górski. Idealny do jazdy po górach. Nawet w mieście z ziomakmi pojezdzisz. Sprawdz!",
                            Brand = "Kross",
                            Model = "Hexagon 6.0",
                            Availability = true,
                            Condition = "Nowe",
                            Size = "L",
                            QuantityInStock = 15,
                            PricePerDay = 170,
                            ImageUrl = "/images/no-image-icon.png"

                        });
                    }

                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Feedbacks.Any())
                {
                    _dbContext.Feedbacks.Add(new Feedback
                    {
                        EquipmentId = 2,
                        Rating = 5,
                        Comment = "Great equipment!",
                        FeedbackDate = DateTime.Now
                    });
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Rentals.Any())
                {
                    _dbContext.Rentals.Add(new Rental
                    {
                        RentalId = 1,
                        EquipmentId = 1,
                        RentalDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(7),
                        Status = Rental.RentalStatus.Active,
                        Quantity = 2,
                        CustomerName = "Karina",
                        CustomerSurname = "Krotkiewicz",
                        CustomerEmail = "karina@vp.pl",
                        CustomerPhone = "99711"
                    }); 
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
