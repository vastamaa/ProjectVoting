using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Interfaces;

namespace ProjectVoting.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task AddUserToRole(UserRegistration userModel, string role)
        {
            await _userManager.AddToRoleAsync(_mapper.Map<User>(userModel), role);
        }

        public async Task<IdentityResult> RegisterUser(UserRegistration userModel)
        {
            return await _userManager.CreateAsync(_mapper.Map<User>(userModel), userModel.Password);
        }

        public async Task<bool> LoginAsync(UserLogin userModel)
        {
            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
