using AutoMapper;
using RentalStore.SharedKernel.Dto;
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
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public int Create(CreateRentalDto dto)
        {
            var rental = _mapper.Map<Rental>(dto);
            _uow.RentalRepository.Insert(rental);
            _uow.Commit();

            return rental.RentalId;
        }

        public void Delete(int id)
        {
            var rental = _uow.RentalRepository.Get(id);
            if (rental == null)
            {
                throw new NotFoundException("Rental not found");
            }

            _uow.RentalRepository.Delete(rental);
            _uow.Commit();
        }

        public RentalDto GetById(int id)
        {
            var rental = _uow.RentalRepository.Get(id);
            if (rental == null)
            {
                throw new NotFoundException("Rental not found");
            }

            return _mapper.Map<RentalDto>(rental);
        }

        public IList<RentalDto> GetAll()
        {
            var rentals = _uow.RentalRepository.GetAll();
            return _mapper.Map<IList<RentalDto>>(rentals);
        }

        public IList<RentalDto> GetActiveRentals()
        {
            var rentals = _uow.RentalRepository.GetActiveRentals();
            return _mapper.Map<IList<RentalDto>>(rentals);
        }

        public void Insert(Rental rental)
        {
            _uow.RentalRepository.Insert(rental);
            _uow.Commit();
        }

        public void Update(int id, UpdateRentalDto dto)
        {
            var rental = _uow.RentalRepository.Get(id);
            if (rental == null)
            {
                throw new NotFoundException("Rental not found");
            }

            _mapper.Map(dto, rental);
            _uow.RentalRepository.Update(rental);
            _uow.Commit();
        }

        /*public void AssignAgreement(int rentalId, Agreement agreement)
        {
            var rental = _uow.RentalRepository.Get(rentalId);
            if (rental == null)
            {
                throw new NotFoundException("Rental not found");
            }

            agreement.RentalId = rentalId;
            _uow.AgreementRepository.Insert(agreement);
            _uow.Commit();
        }*/
    }
}
