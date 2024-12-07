namespace Online.Entities;

public class User
{
    public int Id { get; set; } // Автоматично генерується базою даних (SERIAL PRIMARY KEY)
    public string Username { get; set; } = string.Empty; // Ім'я користувача
    public string Email { get; set; } = string.Empty; // Унікальний email користувача
    public string Password { get; set; } = string.Empty; // Зашифрований пароль
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Дата створення
}
