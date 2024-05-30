using FluentValidation;
using RentalStore.Application.Dto;

namespace RentalStore.Application.Validators
{
    public class LocationMapDtoValidator : AbstractValidator<LocationMapDto>
    {
        public LocationMapDtoValidator()
        {
            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("Location ID must be greater than 0.");

            RuleFor(x => x.EquipmentId)
                .GreaterThan(0).WithMessage("Equipment ID must be greater than 0.");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address can't be longer than 200 characters.");

            RuleFor(x => x.Equipment)
                .NotNull().WithMessage("Equipment is required.")
                .SetValidator(new EquipmentDtoValidator());
        }
    }
}
