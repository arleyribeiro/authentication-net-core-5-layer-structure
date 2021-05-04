using AutoMapper;
using Core.Interfaces.Security;
using Core.Interfaces.Services;
using Core.Validators;
using Domain.Entities;
using Domain.DTOs.Request;
using Infrastructure.Interfaces.Repositories;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<string> Login(string username, string password)
        {
            var account = await _userRepository.GetUserAsync(username).ConfigureAwait(false);
            if (account != null && Authenticate(account.Password, password))
            {
                var token = _tokenService.GenerateToken(account);
                return token;
            }
            return null;
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
                throw new ArgumentException("Required register");

            var validator = new RegisterValidator();
            var results = validator.Validate(register);

            if (!results.IsValid)
            {
                var errors = new List<string>();
                foreach (var item in results.Errors)
                {
                    errors.Add(item.ErrorMessage);
                }
                throw new ArgumentException(String.Join("/n", errors));
            }
        }

        private async Task<bool> Insert(User user)
        {
            try
            {
                user.Password = _passwordHasher.HashPassword(user.Password);
                var id = await _userRepository.Insert(user).ConfigureAwait(false);
                return id > 0;
            }
            catch (Exception)
            {
                // handle error
                return false;
            }
        }
    }
}