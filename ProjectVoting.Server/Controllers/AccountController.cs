﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Interfaces;
using ProjectVoting.Infrastructure.Persistence.Models;
using ProjectVoting.Server.Filters;
using System.Diagnostics.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectVoting.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ExcludeFromCodeCoverage]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST api/<AccountController>
        [HttpPost(nameof(Register))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register(UserRegistration userModel)
        {
            var isRegistered = await _accountService.RegisterUser(userModel);

            return isRegistered ? Ok() : BadRequest(userModel);
        }

        [HttpPost(nameof(Login))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Login(UserLogin userModel)
        {
            var LoggedIn = await _accountService.LoginAsync(userModel);

            return LoggedIn ? Ok() : BadRequest(userModel);
        }

        [HttpPost(nameof(Logout))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();

            return Ok();
        }

        [HttpGet(nameof(GetAllUsers))]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _accountService.GetAllUsers();
        }
    }
}
