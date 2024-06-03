using Microsoft.EntityFrameworkCore;
using RentalStore.Domain.Interfaces;
using RentalStore.Domain.Models;
using System.Linq.Expressions;

namespace RentalStore.Infrastructure.Repositories
{
    // Implementacja repozytoriów specyficznych
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly RentalStoreDbContext _rentalStoreDbContext;

        public CategoryRepository(RentalStoreDbContext context)
            : base(context)
        {
            _rentalStoreDbContext = context;
        }

        public int GetMaxId()
        {
            return _rentalStoreDbContext.Categories.Max(x => x.CategoryId);
        }

        public Category GetCategoryByName(string name)
        {
            return _rentalStoreDbContext.Categories.FirstOrDefault(e => e.CategoryName == name);
        }

        
    }
}
