using MediatR;

namespace Online.ReviewAndRating.Application.Commands;

public class CreateReviewCommand : IRequest<Guid>
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}