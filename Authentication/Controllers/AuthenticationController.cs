using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Core.Interfaces.Services;
using Domain.DTOs.Request;
using Domain.Entities;

namespace Authentication.Controllers
{
    [Route("v1/account")]
    public class AuthenticationController : Controller
    {
        private readonly IAccountService _accountService;
        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] AuthenticateRequest model)
        {
            var token = await _accountService.Login(model.Username, model.Password);
            return new
            {
                token = token
            };
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterRequest user)
        {
            var _user = new User { Username = user.Username, Password = user.Password, Role = user.Role };
            var result = await _accountService.Register(_user).ConfigureAwait(false);
            return result;
        }
    }
}
