using Microsoft.AspNetCore.Identity;
using ProjectVoting.ApplicationCore.DTOs;

namespace ProjectVoting.ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUser(UserRegistration userModel);
        Task AddUserToRole(UserRegistration userModel, string role);
        Task<bool> LoginAsync(UserLogin userModel);
        Task LogoutAsync();

    }
}
