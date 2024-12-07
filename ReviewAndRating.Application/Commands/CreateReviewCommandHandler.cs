using MediatR;
using ReviewAndRating.Domain.Entities;
using ReviewAndRating.Domain.Interfaces;

namespace Online.ReviewAndRating.Application.Commands;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            UserId = request.UserId,
            Comment = request.Comment,
            Rating = request.Rating,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.ReviewRepository.AddReviewAsync(review);
        await _unitOfWork.SaveChangesAsync();

        return review.Id;
    }
}