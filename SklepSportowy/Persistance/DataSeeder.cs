﻿using SklepSportowy.Models;

namespace SklepSportowy.Persistance
{
    public class DataSeeder
    {
        private readonly SklepDbContext _dbContext;

        public DataSeeder(SklepDbContext context)
        {
            this._dbContext = context;
        }

        public void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
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
            }
        }
    }
}
