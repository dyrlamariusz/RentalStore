using FluentValidation;
using RentalStore.SharedKernel.Dto;

namespace RentalStore.Application.Validators
{
    public class RentalDtoValidator : AbstractValidator<RentalDto>
    {
        public RentalDtoValidator()
        {
            RuleFor(x => x.RentalId)
                .GreaterThan(0).WithMessage("Rental ID must be greater than 0.");

            RuleFor(x => x.EquipmentId)
                .GreaterThan(0).WithMessage("Equipment ID must be greater than 0.");

            RuleFor(x => x.AgreementId)
                .GreaterThan(0).WithMessage("Agreement ID must be greater than 0.");

            RuleFor(x => x.RentalDate)
                .NotEmpty().WithMessage("Rental date is required.");

            RuleFor(x => x.ReturnDate)
                .GreaterThan(x => x.RentalDate).WithMessage("Return date must be later than the rental date.")
                .NotEmpty().WithMessage("Return date is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status can't be longer than 50 characters.");
        }
    }
}
