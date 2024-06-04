using FluentValidation;
using RentalStore.Domain.Interfaces;
using RentalStore.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Application.Validators
{
    public class RegisterCreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        //public RegisterCreateProductDtoValidator()
        //{
        //    RuleFor(p => p.Name)
        //        .NotEmpty()
        //        .MinimumLength(2)
        //        .MaximumLength(20);

        //    RuleFor(p => p.Desc)
        //        .NotEmpty()
        //        .MinimumLength(2)
        //        .MaximumLength(20);

        //    RuleFor(p => p.UnitPrice)
        //        .GreaterThan(0);
        //}

        public RegisterCreateProductDtoValidator(IRentalStoreUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(p => p.Desc)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(p => p.UnitPrice)
                .GreaterThan(0);

            RuleFor(s => s.Name)
                .Custom((value, context) =>
                {
                    bool inUse = unitOfWork.ProductRepository.IsInUse(value);
                    if (inUse)
                    {
                        context.AddFailure("Name", "Product name is in use");
                    }
                });
        }

    }
}
