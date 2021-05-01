using Core.Interfaces.Security;
using Core.Interfaces.Services;
using Core.Services;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Moq;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Tests.CoreTests
{
    public class CreateUserTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IPasswordHasher> _passwordHasher;
        private readonly Mock<ITokenService> _tokenService;
        private readonly IAccountService _accountService;
        public CreateUserTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _tokenService = new Mock<ITokenService>();
            _passwordHasher = new Mock<IPasswordHasher>();
            _accountService = new AccountService(_userRepository.Object, _passwordHasher.Object, _tokenService.Object);
        }

        [Fact]
        public async Task ValidateRole()
        {
            var user = new User();
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _accountService.Register(user));
            Assert.Equal("ROLE: Must be manager or employee", exception.Message);
        }
    }
}