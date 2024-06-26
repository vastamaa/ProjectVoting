﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Interfaces;
using ProjectVoting.Infrastructure.Persistence.Models;

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

        public async Task<bool> RegisterUser(UserRegistration userModel)
        {
            var result = await _userManager.CreateAsync(_mapper.Map<User>(userModel), userModel.Password);

            return result.Succeeded;
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

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
