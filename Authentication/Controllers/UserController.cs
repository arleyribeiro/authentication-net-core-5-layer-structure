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
    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult<dynamic>> GetAllAsync()
        {
            var users = await _accountService.GetAllAsync().ConfigureAwait(false);
            return new
            {
                users = users
            };
        }
    }
}
