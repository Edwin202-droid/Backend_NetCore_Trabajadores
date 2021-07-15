using System.Data;
namespace Data.ADOconexion
{
    public interface IFactoryConnection
    {
        void CloseConnection();
        IDbConnection GetDbConnection();
    }
}