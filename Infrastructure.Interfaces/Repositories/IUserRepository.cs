using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryAsync<User>
    {
        Task<User> GetUserAsync(string username);
        Task<int> Insert(User user);
    }
}