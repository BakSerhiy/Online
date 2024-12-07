using Online.Contracts;
using Online.Entities;


namespace Online.Services;

    
public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public AuthService(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    // Реєстрація користувача
    public void Register(User user)
    {
        _userRepository.Add(user);
        var defaultRole = _roleRepository.GetAll().FirstOrDefault(r => r.RoleName == "User");
        if (defaultRole != null)
        {
            _userRepository.AddRoleToUser(user.Id, defaultRole.Id);
        }
    }

    // Авторизація користувача
    public User Login(string email, string password)
    {
        var user = _userRepository.GetAll().FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            throw new Exception("Невірні дані для авторизації");
        }
        return user;
    }

    // Редагування профілю користувача
    public void EditProfile(int userId, User updatedUser)
    {
        var user = _userRepository.GetById(userId);
        if (user != null)
        {
            user.Username = updatedUser.Username;  // Використовуємо Username
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            _userRepository.Update(user);
        }
        else
        {
            throw new Exception("Користувача не знайдено");
        }
    }
}