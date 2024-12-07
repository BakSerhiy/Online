using MediatR;
using Online.ReviewAndRating.Application.DTOs;


namespace Online.ReviewAndRating.Application.Queries;

public class GetReviewsByProductQuery : IRequest<IEnumerable<ReviewDTO>>
{
    public Guid ProductId { get; set; }

    public GetReviewsByProductQuery(Guid productId)
    {
        ProductId = productId;
    }
}