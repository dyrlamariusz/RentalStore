namespace SklepSportowy.Persistance
{
    // implementacja Unit of Work
    // zarządzanie repozytorium i transakcjami
    public class SklepUnitOfWork 
    {
        private readonly SklepDbContext _context;

        public IProductRepository ProductRepository { get; }

        public SklepUnitOfWork(SklepDbContext context, IProductRepository productRepository)
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
