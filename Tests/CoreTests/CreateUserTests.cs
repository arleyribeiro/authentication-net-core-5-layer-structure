using AutoMapper;
using Core.Interfaces.Security;
using Core.Interfaces.Services;
using Core.Services;
using Core.Exceptions;
using Domain.Entities;
using Domain.Constants;
using Infrastructure.Interfaces.Repositories;
using Moq;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Domain.DTOs.Request;
using Domain.DTOs.Response;

namespace Tests.CoreTests
{
    public class CreateUserTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IPasswordHasher> _passwordHasher;
        private readonly Mock<ITokenService> _tokenService;
        private readonly IAccountService _accountService;
        private readonly Mock<IMapper> _mapper;
        public CreateUserTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _tokenService = new Mock<ITokenService>();
            _passwordHasher = new Mock<IPasswordHasher>();
            _mapper = new Mock<IMapper>();
            _accountService = new AccountService(_mapper.Object, _userRepository.Object, _passwordHasher.Object, _tokenService.Object);
        }

        [Fact]
        public async Task ValidateRole()
        {
            var user = new RegisterRequest();
            var exception = await Assert.ThrowsAsync<ArgumentBusinessException>(() => _accountService.Register(user));
            var errors = exception.Errors;
            Assert.NotNull(errors);
        }


        [Fact]
        public async Task ValidateRoleRequiredParameters()
        {
            var user = new RegisterRequest();
            var exception = await Assert.ThrowsAsync<ArgumentBusinessException>(() => _accountService.Register(user));
            var errors = exception.Errors;
            Assert.NotNull(errors);
            Assert.Collection(errors,
                item => Assert.Equal(item.Code, ErrorsConstants.REQUIRED_PARAMETER),
                item => Assert.Equal(item.Code, ErrorsConstants.REQUIRED_PARAMETER),
                item => Assert.Equal(item.Code, ErrorsConstants.Register.INVALID_ROLE)
            );
        }
    }
}