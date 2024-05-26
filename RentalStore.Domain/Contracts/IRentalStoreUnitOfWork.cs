namespace RentalStore.Domain.Contracts
{
    public interface IRentalStoreUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        void Commit();
    }
}
