using RentalStore.Domain.Contracts;

namespace RentalStore.Infrastructure
{
    // implementacja Unit of Work
    public class RentalStoreUnitOfWork : IRentalStoreUnitOfWork
    {
        private readonly RentalStoreDbContext _context;

        public IProductRepository ProductRepository { get; }

        public RentalStoreUnitOfWork(RentalStoreDbContext context, IProductRepository productRepository)
        {
            this._context = context;
            this.ProductRepository = productRepository;

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
