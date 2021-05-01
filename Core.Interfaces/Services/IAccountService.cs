using System.Threading.Tasks;
using Domain.Entities;
using Core.Interfaces.Services;

namespace Core.Interfaces.Services
{
    public interface IAccountService : IServiceBase<User>
    {
        Task<string> Login(string username, string password);
        Task<bool> Register(User user);
    }
}