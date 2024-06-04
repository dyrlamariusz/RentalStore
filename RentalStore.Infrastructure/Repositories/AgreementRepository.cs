using RentalStore.Domain.Interfaces;
using RentalStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Infrastructure.Repositories
{
    /*public class AgreementRepository : Repository<Agreement>, IAgreementRepository
    {
        private readonly RentalStoreDbContext _rentalStoreDbContext;

        public AgreementRepository(RentalStoreDbContext context)
            : base(context)
        {
            _rentalStoreDbContext = context;
        }

        public int GetMaxId()
        {
            return _rentalStoreDbContext.Agreements.Max(x => x.AgreementId);
        }
    }*/
}
