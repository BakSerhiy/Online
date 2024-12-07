using Dapper;
using Online.Context;
using Online.Contracts;
using Online.Entities;

namespace Online.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context) : base(context)
    {
        _context = context;
    }

    public void AddRoleToUser(int userId, int roleId)
    {
        using (var connection = _context.GetConnection())
        {
            string sql = "INSERT INTO user_roles (user_id, role_id) VALUES (@UserId, @RoleId)";
            connection.Execute(sql, new { UserId = userId, RoleId = roleId });
        }
    }

    public void RemoveRoleFromUser(int userId, int roleId)
    {
        using (var connection = _context.GetConnection())
        {
            string sql = "DELETE FROM user_roles WHERE user_id = @UserId AND role_id = @RoleId";
            connection.Execute(sql, new { UserId = userId, RoleId = roleId });
        }
    }

    public IEnumerable<Role> GetRolesForUser(int userId)
    {
        using (var connection = _context.GetConnection())
        {
            string sql = @"SELECT r.* FROM roles r
                               INNER JOIN user_roles ur ON r.id = ur.role_id
                               WHERE ur.user_id = @UserId";
            return connection.Query<Role>(sql, new { UserId = userId });
        }
    }
}