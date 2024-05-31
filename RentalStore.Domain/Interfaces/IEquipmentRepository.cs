using RentalStore.Domain.Models;

namespace RentalStore.Domain.Interfaces
{
    // interfejsy repozytoriów specyficznych
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        IList<Equipment> GetAvailableEquipments();
        Equipment GetEquipmentByName(string name);
        Equipment GetEquipmentByCategory(string categoryName);

        //skopiowane z IProductRepository
        int GetMaxId();
        //bool IsInUse(string email);
    }
}
