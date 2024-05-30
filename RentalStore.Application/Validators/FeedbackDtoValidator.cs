using FluentValidation;
using RentalStore.SharedKernel.Dto;

namespace RentalStore.Application.Validators
{
    public class FeedbackDtoValidator : AbstractValidator<FeedbackDto>
    {
        public FeedbackDtoValidator()
        {
            RuleFor(x => x.FeedbackId)
                .GreaterThan(0).WithMessage("Feedback ID must be greater than 0.");

            RuleFor(x => x.EquimentId)
                .GreaterThan(0).WithMessage("Equipment ID must be greater than 0.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.Comment)
                .MaximumLength(1000).WithMessage("Comment can't be longer than 1000 characters.");

            RuleFor(x => x.FeedbackDate)
                .NotEmpty().WithMessage("Feedback date is required.");

            RuleFor(x => x.Equipment)
                .NotNull().WithMessage("Equipment is required.")
                .SetValidator(new EquipmentDtoValidator());
        }
    }
}
