using ReviewAndRating.Domain.Interfaces;

namespace Online.ReviewAndRating.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ReviewAndRatingDbContext _context;

    public UnitOfWork(ReviewAndRatingDbContext context, IReviewRepository reviewRepository)
    {
        _context = context;
        ReviewRepository = reviewRepository;
    }

    public IReviewRepository ReviewRepository { get; }

    public async Task<int> SaveChangesAsync() // Повертаємо кількість змінених рядків
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}