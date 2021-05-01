using System.Data;

namespace Infrastructure.Interfaces.DBConfiguration
{
    public interface IDatabaseProvider
    {
        IDbConnection GetConnection();
        void SetStringConnection(string typeConnection);
    }
}