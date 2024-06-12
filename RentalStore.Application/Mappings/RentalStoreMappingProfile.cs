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

            

            // mapowanie dla obiektów DTO
            // ODKOMENTOWAC
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentDto, Equipment>();

            CreateMap<Equipment, EquipmentDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    var category = context.Items["categories"] as IEnumerable<Category>;
                    return category?.FirstOrDefault(c => c.CategoryId == src.CategoryId)?.CategoryName;
                }));


            CreateMap<CreateEquipmentDto, Equipment>();
            CreateMap<UpdateEquipmentDto, Equipment>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryDto, Category>();

            // Mapowanie dla obiektów Rental
            CreateMap<Rental, RentalDto>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
                .ReverseMap();

            CreateMap<CreateRentalDto, Rental>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details));

            CreateMap<UpdateRentalDto, Rental>();

            // Mapowanie dla obiektów RentalDetail
            CreateMap<RentalDetail, RentalDetailDto>().ReverseMap();
            CreateMap<CreateRentalDetailDto, RentalDetail>();

            // Mapowanie dla obiektów RentalStatus
            CreateMap<RentalStatus, RentalStatusDto>().ReverseMap();

            CreateMap<Agreement, AgreementDto>().ReverseMap();

            /*CreateMap<Agreement, AgreementDto>();
            CreateMap<AgreementDto, Agreement>();*/

            CreateMap<Maintenance, MaintenanceDto>();
            CreateMap<MaintenanceDto, Maintenance>();

            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();

            

            CreateMap<Feedback, FeedbackDto>();
            CreateMap<FeedbackDto, Feedback>();

            CreateMap<LocationMap, LocationMapDto>();
            CreateMap<LocationMapDto, LocationMap>();

            CreateMap<RentalStatus, RentalStatusDto>().ReverseMap();
            //CreateMap<RentalDetail, Rental>().ReverseMap();



        }
    }
}
