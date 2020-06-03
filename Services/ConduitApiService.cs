using BlazorConduit.Models.Authentication.Requests;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Services
{
    public class ConduitApiService
    {
        private readonly HttpClient _httpClient;

        public ConduitApiService(HttpClient httpClient) =>
            _httpClient = httpClient;

        public Task<HttpResponseMessage> RegisterUser(RegisterUserRequest request)
        {
            return _httpClient.PostAsJsonAsync("users", request);
        }

        public Task<HttpResponseMessage> LoginUser(LoginUserRequest request)
        {
            return _httpClient.PostAsJsonAsync("users/login", request);
        }
    }
}
