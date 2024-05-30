using FluentValidation;
using RentalStore.SharedKernel.Dto;

namespace RentalStore.Application.Validators
{
    public class PaymentDtoValidator : AbstractValidator<PaymentDto>
    {
        public PaymentDtoValidator()
        {
            RuleFor(x => x.PaymentId)
                .GreaterThan(0).WithMessage("Payment ID must be greater than 0.");

            RuleFor(x => x.RentalId)
                .GreaterThan(0).WithMessage("Rental ID must be greater than 0.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PaymentDate)
                .NotEmpty().WithMessage("Payment date is required.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.")
                .MaximumLength(50).WithMessage("Payment method can't be longer than 50 characters.");

            RuleFor(x => x.Rental)
                .NotNull().WithMessage("Rental is required.")
                .SetValidator(new RentalDtoValidator());
        }
    }
}
