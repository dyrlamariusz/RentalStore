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
    public class EquipmentService:IEquipmentService
    {
        private readonly IRentalStoreUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EquipmentService(IRentalStoreUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(CreateEquipmentDto dto)
        {
            var category = _uow.CategoryRepository.Find(c => c.CategoryName == dto.CategoryName).FirstOrDefault();
            if (category == null)
            {
                throw new BadRequestException("Invalid category name");
            }

            var equipment = _mapper.Map<Equipment>(dto);
            equipment.CategoryId = category.CategoryId; // Ustawianie CategoryId na podstawie znalezionej kategorii
            _uow.EquipmentRepository.Insert(equipment);
            _uow.Commit();
            return equipment.EquipmentId;
        }
    

        public void Delete(int id)
        {
            var equipment = _uow.EquipmentRepository.Get(id);
            if (equipment == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            _uow.EquipmentRepository.Delete(equipment);
            _uow.Commit();
        }

        public List<EquipmentDto> GetAll()
        {
            var equipment = _uow.EquipmentRepository.GetAll();

            List<EquipmentDto> result = _mapper.Map<List<EquipmentDto>>(equipment);
            return result;
        }

        public EquipmentDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var equipment = _uow.EquipmentRepository.Get(id);
            if (equipment == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            var result = _mapper.Map<EquipmentDto>(equipment);
            return result;
        }

        public void Update(int id, UpdateEquipmentDto dto)
        {
            var equipment = _uow.EquipmentRepository.Get(id);
            if (equipment == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            var category = _uow.CategoryRepository.GetCategoryByName(dto.CategoryName);
            if (category == null)
            {
                throw new BadRequestException("Invalid category name");
            }

            // Mapuj wartości z DTO do istniejącego rekordu
            _mapper.Map(dto, equipment);
            equipment.CategoryId = category.CategoryId; // Ustaw ID kategorii

            // Zaktualizuj rekord
            _uow.EquipmentRepository.Update(equipment);
            _uow.Commit();
        }
    }
}