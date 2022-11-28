using Core.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Data
{
    public class DatabaseContext : IDatabaseContext
    {

        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        private NpgsqlConnection _connection;


        /// <summary>
        /// Get connection string inside constructor.
        /// So when the class will be initialized then connection string will be automatically get from appsettings.json
        /// </summary>
        /// <param name="configuration"></param>
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionStrings")["DefaultConnection"] ?? "";
        }


        /// <summary>
        /// Gets the connection.
        /// </summary>
        public NpgsqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new NpgsqlConnection(_connectionString);
            }
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }


        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
