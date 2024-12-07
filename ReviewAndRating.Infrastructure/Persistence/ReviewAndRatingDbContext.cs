using Microsoft.EntityFrameworkCore;
using ReviewAndRating.Domain.Entities;

namespace Online.ReviewAndRating.Infrastructure.Persistence;

public class ReviewAndRatingDbContext : DbContext
{
    public DbSet<Review> Reviews { get; set; }

    public ReviewAndRatingDbContext(DbContextOptions<ReviewAndRatingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReviewAndRatingDbContext).Assembly);
    }
}