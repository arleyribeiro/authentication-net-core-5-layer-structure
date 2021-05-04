using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTOs.Request;
using Core.Interfaces.Services;

namespace Core.Interfaces.Services
{
    public interface IAccountService : IServiceBase<User>
    {
        Task<string> Login(string username, string password);
        Task<bool> Register(RegisterRequest user);
    }
}