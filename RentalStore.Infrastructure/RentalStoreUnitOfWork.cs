using RentalStore.Domain.Interfaces;

namespace RentalStore.Infrastructure
{
    // implementacja Unit of Work
    public class RentalStoreUnitOfWork : IRentalStoreUnitOfWork
    {
        private readonly RentalStoreDbContext _context;

        public IProductRepository ProductRepository { get; } // DO USUNIECIA
        public IEquipmentRepository EquipmentRepository { get; }
        public IRentalRepository RentalRepository { get; }


        public RentalStoreUnitOfWork(RentalStoreDbContext context, IEquipmentRepository equipmentRepository, IProductRepository productRepository, IRentalRepository rentalRepository)
        {
            this._context = context;
            this.EquipmentRepository = equipmentRepository;
            this.ProductRepository = productRepository;
            this.RentalRepository = rentalRepository;
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
