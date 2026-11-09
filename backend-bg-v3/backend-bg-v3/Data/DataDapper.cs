using Microsoft.Data.SqlClient;
using System.Data;

namespace backend_bg_v3.Data
{
    public class DataDapper
    {
        private readonly string _connectionString;

        public DataDapper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")?? throw new InvalidOperationException(
                "No se encontró DefaultConnection."
            );
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
