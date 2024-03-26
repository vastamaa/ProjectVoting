using ProjectVoting.ApplicationCore.Interfaces;
using ProjectVoting.Infrastructure.Persistence.Models;
using System.Text.Json;

namespace ProjectVoting.ApplicationCore.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpRequestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var client = _httpClientFactory.CreateClient("API");

            using (var result = await client.GetAsync("api/Account/GetAllUsers"))
            {
                result.EnsureSuccessStatusCode();

                var jsonString = await result.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<User>>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
    }
}
