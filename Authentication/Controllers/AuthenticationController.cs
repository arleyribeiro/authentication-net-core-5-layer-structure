using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Core.Interfaces.Services;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
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
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest model)
        {
            var result = await _accountService.Login(model).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterRequest user)
        {
            var result = await _accountService.Register(user).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
