using FluentValidation;
using RentalStore.Application.Dto;

namespace RentalStore.Application.Validators
{
    public class EquipmentDtoValidator : AbstractValidator<EquipmentDto>
    {
        public EquipmentDtoValidator()
        {
            RuleFor(x => x.EquipmentId)
                .GreaterThan(0).WithMessage("Equipment ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name can't be longer than 100 characters.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be greater than 0.");

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required.")
                .MaximumLength(50).WithMessage("Brand can't be longer than 50 characters.");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required.")
                .MaximumLength(50).WithMessage("Model can't be longer than 50 characters.");

            RuleFor(x => x.Condition)
                .NotEmpty().WithMessage("Condition is required.")
                .MaximumLength(100).WithMessage("Condition can't be longer than 100 characters.");

            RuleFor(x => x.Size)
                .NotEmpty().WithMessage("Size is required.")
                .MaximumLength(50).WithMessage("Size can't be longer than 50 characters.");

            RuleFor(x => x.Category)
                .NotNull().WithMessage("Category is required.")
                .SetValidator(new CategoryDtoValidator());

            RuleForEach(x => x.Rentals).SetValidator(new RentalDtoValidator());
            RuleForEach(x => x.Feedbacks).SetValidator(new FeedbackDtoValidator());
            RuleForEach(x => x.Maintenances).SetValidator(new MaintenanceDtoValidator());
            RuleForEach(x => x.LocationMaps).SetValidator(new LocationMapDtoValidator());
        }
    }
}
