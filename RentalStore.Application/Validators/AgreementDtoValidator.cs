using FluentValidation;
using RentalStore.Application.Dto;

public class AgreementDtoValidator : AbstractValidator<AgreementDto>
{
    public AgreementDtoValidator()
    {
        RuleFor(x => x.AgreementId).NotEmpty().WithMessage("Agreement ID is required.");

        RuleFor(x => x.RentalId).NotEmpty().WithMessage("Rental ID is required.");

        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Customer name is required.")
            .MaximumLength(100).WithMessage("Customer name can't be longer than 100 characters.");

        RuleFor(x => x.CustomerIdNumber)
            .NotEmpty().WithMessage("Customer ID number is required.")
            .MaximumLength(20).WithMessage("Customer ID number can't be longer than 20 characters.");

        RuleFor(x => x.CustomerEmail)
            .NotEmpty().WithMessage("Customer email is required.")
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(x => x.CustomerPhoneNumber)
            .NotEmpty().WithMessage("Customer phone number is required.")
            .MaximumLength(15).WithMessage("Customer phone number can't be longer than 15 characters.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

        RuleFor(x => x.CustomerAdress)
            .NotEmpty().WithMessage("Customer address is required.")
            .MaximumLength(200).WithMessage("Customer address can't be longer than 200 characters.");

        RuleFor(x => x.AgreementDate).NotEmpty().WithMessage("Agreement date is required.");

        RuleFor(x => x.Rental).NotNull().WithMessage("Rental is required.");
    }
}