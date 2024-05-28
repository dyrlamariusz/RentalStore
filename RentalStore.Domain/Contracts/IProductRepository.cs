

using RentalStore.Domain.Models;

namespace RentalStore.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface IProductRepository : IRepository<Product>
    {
        int GetMaxId();
        bool IsInUse(string email);
    }
}
