using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewAndRating.Domain.Entities;

namespace Online.ReviewAndRating.Infrastructure.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Comment)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(r => r.Rating)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .IsRequired();
        builder.Property(r => r.UpdatedAt).IsRequired(false);

        builder.HasIndex(r => r.ProductId); // Індекс для швидкого пошуку
        builder.HasIndex(r => r.UserId);
    }
}