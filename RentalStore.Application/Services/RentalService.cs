using AutoMapper;
using RentalStore.Application.Dto;
using RentalStore.Domain.Exceptions;
using RentalStore.Domain.Interfaces;
using RentalStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalStoreUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RentalService(IRentalStoreUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(CreateRentalDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Rental is null");
            }

            var rental = _mapper.Map<Rental>(dto);

            _uow.RentalRepository.Insert(rental);
            _uow.Commit();

            return rental.RentalId;
        }

        public void Delete(Rental rental)
        {
            _uow.RentalRepository.Delete(rental);
            _uow.Commit();
        }

        public Rental Get(int id)
        {
            return _uow.RentalRepository.Get(id);
        }
        public IList<Rental> GetAll()
        {
            return _uow.RentalRepository.GetAll();
        }

        public IList<Rental> GetActiveRentals()
        {
            return _uow.RentalRepository.GetActiveRentals();
        }

        public IList<Rental> GetRentalsByAgreementId(int agreementId)
        {
            return _uow.RentalRepository.GetRentalsByAgreementId(agreementId);
        }

        public void Insert(Rental rental)
        {
            _uow.RentalRepository.Insert(rental);
            _uow.Commit();
        }

        public void Update(Rental rental)
        {
            _uow.RentalRepository.Update(rental);
            _uow.Commit();
        }

    }
}
