using RentalStore.Domain.Models;

namespace RentalStore.Domain.Interfaces
{
    // interfejsy repozytoriów specyficznych
    public interface IRentalRepository : IRepository<Rental>
    {

        // NA RAZIE DODANA TYLKO TE METODY (Karina 02.06 21.04)
        IList<Rental> GetActiveRentals();
        //IList<Rental> GetRentalsByAgreementId(int aggrementId);


    }
}
