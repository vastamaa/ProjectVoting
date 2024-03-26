using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.Infrastructure.Persistence.Models;

namespace ProjectVoting.ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task<bool> RegisterUser(UserRegistration userModel);
        Task AddUserToRole(UserRegistration userModel, string role);
        Task<bool> LoginAsync(UserLogin userModel);
        Task LogoutAsync();
        Task<IEnumerable<User>> GetAllUsers();
    }
}
