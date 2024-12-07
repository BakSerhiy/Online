namespace ReviewAndRating.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IReviewRepository ReviewRepository { get; }
    Task<int> SaveChangesAsync();
}