using FluentValidation;
using Online.ReviewAndRating.Application.Commands;

namespace Online.ReviewAndRating.Application.Validators;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment cannot be empty.")
            .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
    }
}