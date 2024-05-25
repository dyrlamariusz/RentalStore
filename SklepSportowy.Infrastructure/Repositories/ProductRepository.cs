using SklepSportowy.Models;

namespace SklepSportowy.Persistance
{
    // Implementacja repozytoriów specyficznych
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly SklepDbContext _sklepDbContext;

        public ProductRepository(SklepDbContext context)
            : base(context)
        {
            _sklepDbContext = context;
        }

        public int GetMaxId()
        {
            return _sklepDbContext.Products.Max(x => x.Id);
        }

        public bool IsNameUnique(string name)
        {
            return _sklepDbContext.Products.Any(p => p.Name == name);
        }

    }
}
