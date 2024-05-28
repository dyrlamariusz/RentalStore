using RentalStore.Domain.Contracts;
using RentalStore.Domain.Models;

namespace RentalStore.Infrastructure.Repositories
{
    // Implementacja repozytoriów specyficznych
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly RentalStoreDbContext _rentalStoreDbContext;

        public ProductRepository(RentalStoreDbContext context)
            : base(context)
        {
            _rentalStoreDbContext = context;
        }

        public int GetMaxId()
        {
            return _rentalStoreDbContext.Products.Max(x => x.Id);
        }

        public bool IsInUse(string name)
        {
            var result = _rentalStoreDbContext.Products.Any(x => x.Name == name);
            return result;
        }
    }
}
