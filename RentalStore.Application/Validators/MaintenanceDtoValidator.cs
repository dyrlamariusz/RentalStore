using FluentValidation;
using RentalStore.Domain.Interfaces;
using RentalStore.SharedKernel.Dto;

namespace RentalStore.Application.Validators
{
    public class MaintenanceDtoValidator : AbstractValidator<MaintenanceDto>
    {
        public MaintenanceDtoValidator()
        {
            RuleFor(x => x.MaintenanceId)
                .GreaterThan(0).WithMessage("Maintenance ID must be greater than 0.");

            RuleFor(x => x.EquipmentId)
                .GreaterThan(0).WithMessage("Equipment ID must be greater than 0.");

            RuleFor(x => x.MaintenenceDate)
                .NotEmpty().WithMessage("Maintenance date is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description can't be longer than 500 characters.");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Cost must be greater than or equal to 0.");

            RuleFor(x => x.NextMaintenanceDate)
                .GreaterThan(x => x.MaintenenceDate)
                .When(x => x.NextMaintenanceDate.HasValue)
                .WithMessage("Next maintenance date must be later than the maintenance date.");

            RuleFor(x => x.Equipment)
                .NotNull().WithMessage("Equipment is required.")
                .SetValidator(new EquipmentDtoValidator());
        }
    }
}
