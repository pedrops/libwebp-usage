using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NetCore.Infraestructure.DataPersistence
{
    public partial class DapperContext : DapperBase
    {
        public DapperContext(IConfiguration configuration) : base(configuration) { }

        public DapperContext(string connectionString) : base(connectionString) { }

        public override IDbConnection CreateConnection() =>
            new SqlConnection(
                !string.IsNullOrEmpty(_connectionString) ?
                _connectionString :
                _configuration.GetConnectionString("SQL") ?? throw new Exception("Unable to create database connection. Missing or invalid connection string."));
    }
}
