using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorConduit.Client.Services.Contracts;

namespace BlazorConduit.Client.Services
{
    public class ConduitApiService : IConduitApiService
    {
        private readonly HttpClient _httpClient;

        public ConduitApiService(HttpClient httpClient) =>
            _httpClient = httpClient;

        public Task<TResponse> GetAsync<TResponse>(string path, string? token = null)
            where TResponse : class
        {
            AttachDefaultAuthenticationHeader(token);
            return _httpClient.GetFromJsonAsync<TResponse>(path);
        }

        public Task<HttpResponseMessage> PostAsync<TBody>(string path, TBody body, string? token = null)
            where TBody : class
        {
            AttachDefaultAuthenticationHeader(token);
            return _httpClient.PostAsJsonAsync(path, body);
        }

        public Task<HttpResponseMessage> PostNoContentAsync(string path, string? token)
        {
            AttachDefaultAuthenticationHeader(token);
            return _httpClient.PostAsync(path, default);
        }

        public Task<HttpResponseMessage> DeleteNoContentAsync(string path, string? token)
        {
            AttachDefaultAuthenticationHeader(token);
            return _httpClient.DeleteAsync(path, default);
        }

        public Task<HttpResponseMessage> PutAsync<TBody>(string path, TBody body, string? token = null)
            where TBody : class
        {
            AttachDefaultAuthenticationHeader(token);
            return _httpClient.PutAsJsonAsync(path, body);
        }

        private void AttachDefaultAuthenticationHeader(string? token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    _httpClient.DefaultRequestHeaders.Remove("Authorization");
                }

                return;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);
        }
    }
}
