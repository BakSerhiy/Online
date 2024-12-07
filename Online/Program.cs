using Online.Context;
using Online.Contracts;
using Online.Repositories;
using Online.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Додаємо DapperContext для підключення до PostgreSQL
builder.Services.AddSingleton<DapperContext>();

// Додаємо підтримку контролерів
builder.Services.AddControllers();

// Реєструємо репозиторії та сервіси
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Включаємо маршрутизацію та контролери
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Мапимо контролери для роботи з API
});

app.Run();