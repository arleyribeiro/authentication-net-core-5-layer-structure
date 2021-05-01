using System;
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Infrastructure.Interfaces.DBConfiguration;

namespace Infrastructure.DBConfiguration
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly IConfiguration _configuration;
        private string _connectionStringName;
        private IDbConnection _connection;

        public DatabaseProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                _connection = new NpgsqlConnection(_connectionStringName);
            }

            return _connection;
        }

        public void SetStringConnection(string typeConnection)
        {
            _connectionStringName = _configuration.GetValue<string>(typeConnection);
        }
    }
}