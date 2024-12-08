using MediatR;
using Online.ReviewAndRating.Infrastructure.Persistence;
using Online.ReviewAndRating.Infrastructure.Repositories;
using ReviewAndRating.Domain.Interfaces;

namespace ReviewAndRating.WebAPI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        // Реєстрація UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Реєстрація репозиторіїв
        services.AddScoped<IReviewRepository, ReviewRepository>();

        // Реєстрація AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Реєстрація MediatR
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    }
}