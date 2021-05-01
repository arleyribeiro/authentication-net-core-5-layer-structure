using Bcrypt = BCrypt.Net.BCrypt;
using Core.Interfaces.Security;

namespace Core.Security
{
    public class BCryptPasswordHahser : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var hashPassword = Bcrypt.HashPassword(password);
            return hashPassword;
        }
        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return Bcrypt.Verify(providedPassword, hashedPassword);
        }
    }
}