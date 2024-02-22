using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Interfaces;
using ProjectVoting.Server.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectVoting.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // POST api/<AccountController>
        [HttpPost(nameof(Register))]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register(UserRegistration userModel)
        {
            var result = await _accountService.RegisterUser(userModel);

            if (!result.Succeeded)
            {
                return BadRequest(userModel);
            }

            return Ok();
        }

        [HttpPost(nameof(Login))]
        [ValidateAntiForgeryToken]
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
    }
}
