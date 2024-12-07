using System.Collections.Generic;
using Dapper;
using Online.Contracts;
using Online.Context;
using Online.Entities;

namespace Online.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DapperContext _context;

        public GenericRepository(DapperContext context)
        {
            _context = context;
        }
 
        public T GetById(int id)
        {
            using (var connection = _context.GetConnection())
            {
                // Припускаючи, що кожна таблиця має колонку "id" як первинний ключ
                string sql = $"SELECT * FROM {typeof(T).Name.ToLower()}s WHERE id = @Id";
                return connection.QuerySingleOrDefault<T>(sql, new { Id = id });
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var connection = _context.GetConnection())
            {
                string sql = $"SELECT * FROM {typeof(T).Name.ToLower()}s";
                return connection.Query<T>(sql);
            }
        }

        public void Add(T entity)
        {
            using (var connection = _context.GetConnection())
            {
                if (typeof(T) == typeof(User))
                {
                    string sql = @"
                        INSERT INTO users (username, email, password, created_at) 
                        VALUES (@Username, @Email, @Password, @CreatedAt)";
                    connection.Execute(sql, entity);
                }
                else if (typeof(T) == typeof(Role))
                {
                    string sql = @"
                        INSERT INTO roles (role_name) 
                        VALUES (@RoleName)";
                    connection.Execute(sql, entity);
                }
                else if (typeof(T) == typeof(UserRole))
                {
                    string sql = @"
                        INSERT INTO userroles (userid, roleid) 
                        VALUES (@UserId, @RoleId)";
                    connection.Execute(sql, entity);
                }
            }
        }

        public void Update(T entity)
        {
            using (var connection = _context.GetConnection())
            {
                if (typeof(T) == typeof(User))
                {
                    string sql = @"
                        UPDATE users 
                        SET username = @Username, email = @Email, password = @Password 
                        WHERE id = @Id";
                    connection.Execute(sql, entity);
                }
                else if (typeof(T) == typeof(Role))
                {
                    string sql = @"
                        UPDATE roles 
                        SET role_name = @RoleName 
                        WHERE id = @Id";
                    connection.Execute(sql, entity);
                }
                else if (typeof(T) == typeof(UserRole))
                {
                    string sql = @"
                        UPDATE userroles 
                        SET userid = @UserId, roleid = @RoleId 
                        WHERE userid = @UserId AND roleid = @RoleId";
                    connection.Execute(sql, entity);
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = _context.GetConnection())
            {
                if (typeof(T) == typeof(User))
                {
                    string sql = "DELETE FROM users WHERE id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
                else if (typeof(T) == typeof(Role))
                {
                    string sql = "DELETE FROM roles WHERE id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
                else if (typeof(T) == typeof(UserRole))
                {
                    // Видаляємо на основі обох ключів (UserId і RoleId)
                    string sql = "DELETE FROM userroles WHERE userid = @Id";
                    connection.Execute(sql, new { Id = id });
                }
            }
        }
    }
}
