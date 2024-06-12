using FluentValidation;
using RentalStore.Domain.Interfaces;
using RentalStore.SharedKernel.Dto;

namespace RentalStore.Application.Validators
{
    public class CreateEquipmentDtoValidator : AbstractValidator<EquipmentDto>
    {
        public CreateEquipmentDtoValidator(IRentalStoreUnitOfWork unitOfWork)
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(e => e.Description)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(e => e.PricePerDay)
                .GreaterThan(0);

            RuleFor(e => e.CategoryName)
                .NotEmpty()
                .Custom((categoryName, context) =>
                {
                    bool categoryExists = unitOfWork.CategoryRepository.GetAll().Any(c => c.CategoryName == categoryName);
                    if (!categoryExists)
                    {
                        context.AddFailure("CategoryName", "Category does not exist");
                    }
                });
        }
    }
}
