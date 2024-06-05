namespace RentalStore.Domain.Interfaces
{
    public interface IRentalStoreUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; } // DO USUNIECIA
        IEquipmentRepository EquipmentRepository { get; }
        IRentalRepository RentalRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        void Commit();
    }
}
