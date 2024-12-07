namespace ReviewAndRating.Domain.Entities;

public class User
{
    public Guid Id { get; set; } // Унікальний ідентифікатор користувача
    public string Username { get; set; } // Ім'я користувача
    public string Email { get; set; } // Email користувача
}