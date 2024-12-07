using Online.Entities;

namespace Online.Contracts;

public interface IUserRepository : IGenericRepository<User>
{
    void AddRoleToUser(int userId, int roleId);
    void RemoveRoleFromUser(int userId, int roleId);
    IEnumerable<Role> GetRolesForUser(int userId);
}