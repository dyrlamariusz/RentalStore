using RentalStore.Application.Dto;
using RentalStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Application.Services
{
    public interface IRentalService
    {
        Rental Get(int id);
        IList<Rental> GetAll();
        void Insert(Rental rental);
        void Update(Rental rental);
        void Delete(Rental rental);
        IList<Rental> GetActiveRentals();
        IList<Rental> GetRentalsByAgreementId(int agreementId);
        int Create(CreateRentalDto dto);
    }
}
