using Microsoft.EntityFrameworkCore;
using Online.ReviewAndRating.Infrastructure.Persistence;
using ReviewAndRating.Domain.Entities;
using ReviewAndRating.Domain.Interfaces;

namespace Online.ReviewAndRating.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ReviewAndRatingDbContext _context;

    public ReviewRepository(ReviewAndRatingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(Guid productId)
    {
        return await _context.Reviews
            .Where(r => r.ProductId == productId)
            .ToListAsync();
    }

    public async Task AddReviewAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }

    public async Task DeleteReviewAsync(Guid reviewId)
    {
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review != null)
        {
            _context.Reviews.Remove(review);
        }
    }

    public async Task UpdateReviewAsync(Review review)
    {
        var existingReview = await _context.Reviews.FindAsync(review.Id);
        if (existingReview != null)
        {
            existingReview.Comment = review.Comment;
            existingReview.Rating = review.Rating;
            existingReview.UpdatedAt = DateTime.UtcNow;
        }
    }
}