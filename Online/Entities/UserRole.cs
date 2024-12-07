namespace Online.Entities;

public class UserRole
{
    public int UserId { get; set; } // ID користувача
    public int RoleId { get; set; } // ID ролі

    // Навігаційні властивості
    public User User { get; set; } // Зв'язок з користувачем
    public Role Role { get; set; } // Зв'язок з роллю
}