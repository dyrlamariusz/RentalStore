using SklepSportowy.Models;

namespace SklepSportowy.Persistance
{
    // interfejsy repozytoriów specyficznych
    public interface IProductRepository : IRepository<Product>
    {
        int GetMaxId();
        bool IsNameUnique(string name);
    }
}
