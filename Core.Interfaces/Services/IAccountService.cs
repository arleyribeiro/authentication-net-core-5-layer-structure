using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Core.Interfaces.Services;

namespace Core.Interfaces.Services
{
    public interface IAccountService : IServiceBase<User>
    {
        Task<LoginResponse> Login(LoginRequest login);
        Task<bool> Register(RegisterRequest user);
    }
}