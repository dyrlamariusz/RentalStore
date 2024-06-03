using Microsoft.EntityFrameworkCore;
using RentalStore.Domain.Interfaces;
using RentalStore.Domain.Models;
using System.Linq.Expressions;

namespace RentalStore.Infrastructure.Repositories
{
    // Implementacja repozytoriów specyficznych
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        private readonly RentalStoreDbContext _rentalStoreDbContext;

        public EquipmentRepository(RentalStoreDbContext context)
            : base(context)
        {
            _rentalStoreDbContext = context;
        }

        public int GetMaxId()
        {
            return _rentalStoreDbContext.Equipments.Max(x => x.EquipmentId);
        }

        
        // DO USUNIECIA (KARINA 03.03. 17:46)
        /*public Equipment Get(int id)
        {
            return _rentalStoreDbContext.Equipments.Find(id);
        } */   
        
       /* public IList<Equipment> GetAll()
        {
            return _rentalStoreDbContext.Equipments.ToList();
        }*/

        /*public void Insert(Equipment entity)
        {
            _rentalStoreDbContext.Equipments.Add(entity);
            _rentalStoreDbContext.SaveChanges();
        }*/

        /*public void Delete(Equipment entity)
        {
            _rentalStoreDbContext.Equipments.Remove(entity);
            _rentalStoreDbContext.SaveChanges();
        }*/

        /*public IList<Equipment> Find(Expression<Func<Equipment, bool>> expression)
        {
            return _rentalStoreDbContext.Equipments.Where(expression).ToList();
        }*/

        public IList<Equipment> GetAvailableEquipments()
        {
            return _rentalStoreDbContext.Equipments.Where(e => e.Availability).ToList();
        }

        public Equipment GetEquipmentByCategory(string categoryName)
        {
            return _rentalStoreDbContext.Equipments
                .Include(e => e.Category)
                .FirstOrDefault(e => e.Category.CategoryName == categoryName);
        }

        public Equipment GetEquipmentByName(string name)
        {
            return _rentalStoreDbContext.Equipments.FirstOrDefault(e => e.Name == name);
        }
        
    }
}
