using Microsoft.EntityFrameworkCore;
using Online.ReviewAndRating.Infrastructure.Persistence;
using Online.ReviewAndRating.Infrastructure.Repositories;
using ReviewAndRating.Domain.Interfaces;

namespace Online.ReviewAndRating.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ReviewAndRatingDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        return services;
    }
}