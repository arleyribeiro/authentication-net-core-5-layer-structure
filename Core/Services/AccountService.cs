using AutoMapper;
using Core.Exceptions;
using Core.Interfaces.Security;
using Core.Interfaces.Services;
using Core.Validators;
using Domain.Entities;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Constants;
using Infrastructure.Interfaces.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountService : ServiceBase<User>, IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountService(IMapper mapper, IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService) : base(userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Login(LoginRequest login)
        {
            var account = await _userRepository.GetUserAsync(login.Username).ConfigureAwait(false);
            if (account != null && Authenticate(account.Password, login.Password))
            {
                var token = _tokenService.GenerateToken(account);
                return new LoginResponse { Token = token };
            }
            throw new UnauthorizedBusinessException(ErrorsConstants.INVALID_LOGIN);
        }
        public bool Authenticate(string hashedPassword, string password)
        {
            return _passwordHasher.VerifyHashedPassword(hashedPassword, password);
        }

        public async Task<bool> Register(RegisterRequest register)
        {
            ValidateRegisterRequest(register);
            var user = _mapper.Map<User>(register);
            return await Insert(user).ConfigureAwait(false);
        }

        private void ValidateRegisterRequest(RegisterRequest register)
        {
            if (register == null)
            {
                throw new ArgumentBusinessException(ErrorsConstants.REQUIRED_PARAMETER);
            }
            RegisterValidator.ValidateAndThrowExceptionIfExistError(register);
        }

        private async Task<bool> Insert(User user)
        {
            try
            {
                user.Password = _passwordHasher.HashPassword(user.Password);
                var id = await _userRepository.Insert(user).ConfigureAwait(false);
                return id > 0 ? true : throw new BusinessException(ErrorsConstants.Register.LOGIN_REGISTRATION_FAILED);
            }
            catch (Exception)
            {
                throw new BusinessException(ErrorsConstants.Register.LOGIN_REGISTRATION_FAILED);
            }
        }
    }
}