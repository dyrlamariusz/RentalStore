﻿using RentalStore.Application.Dto;

namespace RentalStore.Application.Services
{
    public interface IEquipmentService
    {
        List<EquipmentDto> GetAll();
        EquipmentDto GetById(int id);
        int Create(CreateEquipmentDto dto);
        void Update(UpdateEquipmentDto dto);
        void Delete(int id);
    }
}