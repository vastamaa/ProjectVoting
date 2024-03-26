using ProjectVoting.Infrastructure.Persistence.Models;

namespace ProjectVoting.ApplicationCore.Interfaces
{
    public interface IHttpRequestService
    {
        Task<IEnumerable<User>> GetAsync();
    }
}
