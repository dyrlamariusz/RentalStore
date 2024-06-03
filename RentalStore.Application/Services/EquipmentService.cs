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

        public void Update(UpdateEquipmentDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No equipment data");
            }

            var equipment = _uow.EquipmentRepository.Get(dto.EquipmentId);
            if (equipment == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            /*equipment.Name = dto.Name;
            equipment.Brand = dto.Brand;
            equipment.Model = dto.Model;*/

            _uow.Commit();
        }
    }
}