using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorConduit.Services
{
    public class ConduitApiService
    {
        private readonly HttpClient _httpClient; 
        private readonly string _apiBaseUrl;

        public ConduitApiService(IConfiguration configuration, HttpClient httpClient) =>
            (_httpClient, _apiBaseUrl) = (httpClient, configuration["apiBaseUrl"]);

        public Task GetArticles()
        {
            return _httpClient.GetAsync($"{_apiBaseUrl}/articles");
        }
    }
}
