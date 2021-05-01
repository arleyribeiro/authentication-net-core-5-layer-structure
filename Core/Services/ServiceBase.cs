using Core.Interfaces.Services;
using Infrastructure.Interfaces.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryAsync<TEntity> repository;
        public ServiceBase(IRepositoryAsync<TEntity> repository)
        {
            this.repository = repository;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync().ConfigureAwait(false);
        }
    }
}