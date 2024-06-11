using RentalStore.Domain.Models;

namespace RentalStore.Domain.Interfaces
{
    // interfejsy repozytoriów specyficznych
    public interface IRentalRepository : IRepository<Rental>
    {

        
        IList<Rental> GetActiveRentals();
        int GetMaxId();
        Rental GetByIdWithDetails(int id);

        int GetMaxRentalDetailId();

    }
}
