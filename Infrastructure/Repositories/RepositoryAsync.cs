using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly IDatabaseProvider _databaseProvider;
        protected readonly IDbConnection dbConn;
        protected readonly IDbTransaction dbTransaction;
        protected abstract string SelectAllQuery { get; }
        protected RepositoryAsync(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
            _databaseProvider.SetStringConnection("Databases::DefaultConnection");
            dbConn = _databaseProvider.GetConnection();
            dbConn.Open();
        }

        protected RepositoryAsync(IDbConnection databaseConnection, IDbTransaction transaction = null)
        {
            dbConn = databaseConnection;
            if (dbConn.State != ConnectionState.Open)
                dbConn.Open();
            dbTransaction = transaction;
        }

        public void Dispose()
        {
            dbConn.Close();
            dbConn.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbConn.QueryAsync<TEntity>(SelectAllQuery, transaction: dbTransaction).ConfigureAwait(false);
        }
    }
}