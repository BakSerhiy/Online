using ReviewAndRating.Domain.Entities;

namespace ReviewAndRating.Domain.Interfaces;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetReviewsByProductIdAsync(Guid productId);
    Task AddReviewAsync(Review review);
    Task UpdateReviewAsync(Review review);
    Task DeleteReviewAsync(Guid reviewId);
}