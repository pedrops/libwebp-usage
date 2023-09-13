using Dapper;
using NetCore.Domain.Entities.Extensions;
using System.Data;
using System.Reflection;

namespace NetCore.Infraestructure.DataPersistence
{
    public class DBBase
    {
        private DapperBase _context;
        private IDbConnection? _transActionConnection;

        public DBBase(DapperBase context)
        {
            _context = context;
            TraceSQL = _context.SQLTracingEnabled;
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(string query)
        {
            using var connection = _context.CreateConnection();

            if (TraceSQL)
                LogSQL(query);

            return await connection.QueryAsync<T>(query);
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(string query, object parameters)
        {
            using var connection = _context.CreateConnection();

            if (TraceSQL)
                LogSQL(query, parameters);

            return await connection.QueryAsync<T>(query, parameters);
        }

        public async Task<int> ExecuteQuery(string query)
        {
            using var connection = _context.CreateConnection();

            if (TraceSQL)
                LogSQL(query);

            return await connection.ExecuteAsync(query);
        }

        public async Task<int> ExecuteQuery(string query, object parameters)
        {
            using var connection = _context.CreateConnection();

            if (TraceSQL)
                LogSQL(query, parameters);

            return await connection.ExecuteAsync(query, parameters);
        }

        public async Task<T> ExecuteScalarQuery<T>(string query, object parameters)
        {
            using var connection = _context.CreateConnection();

            if (TraceSQL)
                LogSQL(query, parameters);

            return await connection.ExecuteScalarAsync<T>(query, parameters);
        }

        private IDbTransaction Transaction { get; set; } = null!;

        // Using this will impact performance, not meant to run all the time, useful for debugging and outputting SQL.
        public bool TraceSQL { get; set; }
        private List<string> SQLDump { get; set; } = new List<string>();
        public List<string> DumpSQL() => SQLDump ?? new List<string>();

        public void BeginTransaction()
        {
            // This needs to be extended to allow multiple transaction, right now only supports a single per instance
            if (Transaction != null)
                throw new Exception("Transaction in progress");

            _transActionConnection = _context.CreateConnection();
            _transActionConnection.Open();
            Transaction = _transActionConnection.BeginTransaction();
        }

        public int IssueTransactionCommand(string query)
        {
            if (TraceSQL)
                LogSQL(query);

            return
                Transaction.Connection.Execute(query, null, Transaction);
        }

        public T IssueTransactionScalarCommand<T>(string query)
        {
            if (TraceSQL)
                LogSQL(query);

            return
                Transaction.Connection.ExecuteScalar<T>(query, null, Transaction);
        }

        public int IssueTransactionCommand(string query, object parameters)
        {
            if (TraceSQL)
                LogSQL(query, parameters);

            return
                Transaction.Connection.Execute(query, parameters, Transaction);
        }

        public T IssueTransactionScalarCommand<T>(string query, object parameters)
        {
            if (TraceSQL)
                LogSQL(query, parameters);

            return
                Transaction.Connection.ExecuteScalar<T>(query, parameters, Transaction);
        }

        public async Task<T> IssueTransactionScalarCommandAsync<T>(string query, object parameters)
        {
            if (TraceSQL)
                LogSQL(query, parameters);

            return
                await Transaction.Connection.ExecuteScalarAsync<T>(query, parameters, Transaction);
        }

        public void CommitTransaction()
        {
            if (Transaction == null)
                throw new Exception("No transaction found");

            Transaction.Commit();
            CleanupTransaction();
        }

        public void RollbackTransaction()
        {
            if (Transaction == null)
                throw new Exception("No transaction found");

            Transaction.Rollback();
            CleanupTransaction();
        }

        private void CleanupTransaction()
        {
            if (_transActionConnection == null)
                throw new Exception("No transaction found");

            _transActionConnection.Close();
            _transActionConnection.Dispose();

            Transaction = null!;
        }

        public void LogSQL(string query, object? parameters = null)
        {
            try
            {
                // This method will impact application performance, should not be used by default, meant for troubleshooting
                // Set config value to true "TraceSQL" to enable
                if (SQLDump == null)
                    SQLDump = new List<string>();

                var result = query;

                if (parameters == null)
                {
                    SQLDump.Add(result);
                    return;
                }

                var props = new List<PropertyInfo>(parameters.GetType().GetProperties());

                foreach (PropertyInfo prop in props)
                {
                    var propValue = prop.GetValue(parameters, null);

                    // If string or datetime, wrap in '', if JSON block, espace single quotes by doubling them
                    if (propValue != null &&
                        (propValue.GetType() == typeof(string) ||
                        propValue.GetType() == typeof(DateTime)))
                    {
                        result =
                            propValue.ToString()!.IsValidJSON() ?
                                result = result.Replace($"@{prop.Name}", $"'{propValue.ToString()!.Replace("'", "''")}'") :
                                result = result.Replace($"@{prop.Name}", $"'{propValue.ToString()!.Replace("'", "''")}'");
                    }
                    else
                        // If NULL insert null into string, convert bool, else use value
                        result =
                            result.Replace(
                                $"@{prop.Name}",
                                propValue == null ? "null" :
                                    propValue.ToString() == "True" || propValue.ToString() == "true" ?
                                    "1" :
                                        propValue.ToString() == "False" || propValue.ToString() == "false" ?
                                        "0" :
                                        $"{propValue}");
                }
                SQLDump.Add(result);
            }
            catch (Exception ex)
            {
                SQLDump.Add(
                    $"{ex.Message} \r\n" +
                    $"{(ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message + "\r\n" : string.Empty)} " +
                    $"{(ex.InnerException?.InnerException != null ? "Inner Inner Exception: " + ex.InnerException.InnerException.Message + "\r\n" : string.Empty)} " +
                    $"Stack: {ex.StackTrace}");
            }
        }
    }
}
