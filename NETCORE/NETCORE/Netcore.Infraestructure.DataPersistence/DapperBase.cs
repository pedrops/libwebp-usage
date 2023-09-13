using Microsoft.Extensions.Configuration;
using System.Data;

namespace NetCore.Infraestructure.DataPersistence
{
    public abstract partial class DapperBase
    {
        protected IConfiguration? _configuration;
        protected string? _connectionString;

        public DapperBase(IConfiguration configuration) => _configuration = configuration;

        public DapperBase(string connectionString) => _connectionString = connectionString;

        public abstract IDbConnection CreateConnection();

        // Using this will impact performance, not meant to run all the time, useful for debugging and outputting SQL.
        internal bool SQLTracingEnabled => (_configuration?["TraceSql"] ?? "false") == "true";
    }
}