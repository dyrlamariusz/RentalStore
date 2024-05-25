using SklepSportowy.Dto;

namespace SklepSportowy.Db.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        //int Create(CreateProductDto dto);
        //void Update(UpdateProductDto dto);
        //void Delete(int id);
        //bool IsNameUnique(string name);
    }
}
