using Microsoft.EntityFrameworkCore;
using Online.ReviewAndRating.Infrastructure.Persistence;
using Online.ReviewAndRating.Infrastructure.Repositories;
using ReviewAndRating.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Налаштовуємо підключення до бази даних через DbContext
builder.Services.AddDbContext<ReviewAndRatingDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Додаємо інші сервіси (наприклад, для FluentValidation, Repositories тощо)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

// Додаємо контролери
builder.Services.AddControllers();

// Налаштовуємо Swagger (якщо використовується)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Використовуємо Swagger для тестування API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();