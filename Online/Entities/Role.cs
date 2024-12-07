namespace Online.Entities;

public class Role
{
    public int Id { get; set; } // Автоматично генерується базою даних (SERIAL PRIMARY KEY)
    public string RoleName { get; set; } = string.Empty; // Назва ролі
}