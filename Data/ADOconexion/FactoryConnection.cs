using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Data.ADOconexion
{
    public class FactoryConnection : IFactoryConnection
    {
        private IDbConnection connection;
        private readonly IOptions<ConexionConfiguracion> _configs;

        public FactoryConnection(IOptions<ConexionConfiguracion> configs)
        {
            this._configs= configs;
        }
        public void CloseConnection()
        {
            if(connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public IDbConnection GetDbConnection()
        {
            if(connection == null)
            {
                connection = new SqlConnection(_configs.Value.DefaultConnection);
            }
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}