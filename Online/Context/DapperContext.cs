using System.Data;
using Npgsql; // You need this for NpgsqlConnection

namespace Online.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString); // Returns a new PostgreSQL connection
        }
    }
}