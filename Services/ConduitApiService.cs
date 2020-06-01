using BlazorConduit.Models.Authentication.Dtos;
using BlazorConduit.Models.Authentication.RequestModels;
using BlazorConduit.Models.Authentication.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Services
{
    public class ConduitApiService
    {
        private readonly HttpClient _httpClient; 

        public ConduitApiService(HttpClient httpClient) =>
            _httpClient = httpClient;

        public Task<HttpResponseMessage> RegisterUser(AuthenticationRequestModel request)
        {
            return _httpClient.PostAsJsonAsync("/user/register", request);
        }

        public Task GetArticles()
        {
            return _httpClient.GetAsync("/articles");
        }
    }
}
