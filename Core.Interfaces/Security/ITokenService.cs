using Domain.Entities;

namespace Core.Interfaces.Security
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}