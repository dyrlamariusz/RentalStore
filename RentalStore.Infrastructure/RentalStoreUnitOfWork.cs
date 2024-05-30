using RentalStore.Domain.Interfaces;

namespace RentalStore.Infrastructure
{
    // implementacja Unit of Work
    public class RentalStoreUnitOfWork : IRentalStoreUnitOfWork
    {
        private readonly RentalStoreDbContext _context;

        public IProductRepository ProductRepository { get; } // DO USUNIECIA
        public IEquipmentRepository EquipmentRepository { get; }

        public RentalStoreUnitOfWork(RentalStoreDbContext context, IEquipmentRepository equipmentRepository)
        {
            this._context = context;
            this.EquipmentRepository = equipmentRepository;

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
