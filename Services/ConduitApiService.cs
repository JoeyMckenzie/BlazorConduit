using BlazorConduit.Models.Authentication.RequestModels;
using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Services
{
    public class ConduitApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _storageService;

        public ConduitApiService(HttpClient httpClient, ILocalStorageService storageService) =>
            (_httpClient, _storageService) = (httpClient, storageService);

        public Task<HttpResponseMessage> RegisterUser(RegisterUserRequest request)
        {
            return _httpClient.PostAsJsonAsync("users", request);
        }

        public Task GetArticles()
        {
            return _httpClient.GetAsync("articles");
        }
    }
}
