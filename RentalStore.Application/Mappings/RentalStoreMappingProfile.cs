using AutoMapper;
using RentalStore.Domain.Models;
using RentalStore.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Application.Mappings
{
    public class RentalStoreMappingProfile : Profile
    {
        public RentalStoreMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Desc));

            /*CreateMap<Equipment, EquipmentDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
            .ReverseMap()
            .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<EquipmentDto, Equipment>()
           .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<CreateEquipmentDto, Equipment>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());*/

            // mapowanie dla obiektów DTO
            // ODKOMENTOWAC
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentDto, Equipment>();
            CreateMap<CreateEquipmentDto, Equipment>();
            CreateMap<UpdateEquipmentDto, Equipment>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();

            /*CreateMap<Rental, RentalDto>();
            CreateMap<RentalDto, Rental>();*/
            CreateMap<Rental, RentalDto>().ReverseMap();
            CreateMap<CreateRentalDto, Rental>();
            CreateMap<UpdateRentalDto, Rental>();
            CreateMap<Agreement, AgreementDto>().ReverseMap();

            CreateMap<Agreement, AgreementDto>();
            CreateMap<AgreementDto, Agreement>();

            CreateMap<Maintenance, MaintenanceDto>();
            CreateMap<MaintenanceDto, Maintenance>();

            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();

            

            CreateMap<Feedback, FeedbackDto>();
            CreateMap<FeedbackDto, Feedback>();

            CreateMap<LocationMap, LocationMapDto>();
            CreateMap<LocationMapDto, LocationMap>();



        }
    }
}
