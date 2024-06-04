using RentalStore.SharedKernel.Dto;

namespace RentalStore.Application.Services
{
    public interface IEquipmentService
    {
        List<EquipmentDto> GetAll();
        EquipmentDto GetById(int id);
        int Create(CreateEquipmentDto dto);
        void Update(int id, UpdateEquipmentDto dto);
        void Delete(int id);
        List<EquipmentDto> GetEquipmentByCategoryName(string categoryName); 
    }
}
