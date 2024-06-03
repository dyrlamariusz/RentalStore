using RentalStore.Application.Dto;

namespace RentalStore.Application.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        int Create(CreateCategoryDto dto);
        void Update(UpdateCategoryDto dto);
        void Delete(int id);
    }
}
