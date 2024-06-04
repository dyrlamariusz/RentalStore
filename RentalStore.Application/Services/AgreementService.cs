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
    /*public class AgreementService : IAgreementService
    {
        private readonly IRentalStoreUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AgreementService(IRentalStoreUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(CreateAgreementDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Agreement is null");
            }

            var id = _uow.AgreementRepository.GetMaxId() + 1;
            var agreement = _mapper.Map<Agreement>(dto);
            agreement.AgreementId = id;

            _uow.AgreementRepository.Insert(agreement);
            _uow.Commit();

            return id;
        }



        public void Delete(int id)
        {
            var agreement = _uow.AgreementRepository.Get(id);
            if (agreement == null)
            {
                throw new NotFoundException("Agreement not found");
            }

            _uow.ProductRepository.Delete(agreement);
            _uow.Commit();
        }

        public List<AgreementDto> GetAll()
        {
            var agreements = _uow.AgreementRepository.GetAll();

            List<AgreementDto> result = _mapper.Map<List<AgreementDto>>(agreements);
            return result;
        }

        public AgreementDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var agreement = _uow.AgreementRepository.Get(id);
            if (agreement == null)
            {
                throw new NotFoundException("Agreement not found");
            }

            var result = _mapper.Map<AgreementDto>(agreement);
            return result;
        }

        public void Update(UpdateAgreementDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No agreement data");
            }

            var agreement = _uow.AgreementRepository.Get(dto.AgreementId);
            if (agreement == null)
            {
                throw new NotFoundException("Agreement not found");
            }

            _uow.Commit();
        }

        

        List<AgreementDto> IAgreementService.GetAll()
        {
            throw new NotImplementedException();
        }

        AgreementDto IAgreementService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }*/
}