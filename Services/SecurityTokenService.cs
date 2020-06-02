using Blazored.LocalStorage;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Services
{
    public class SecurityTokenService
    {
        private readonly ILocalStorageService _storageService;

        public SecurityTokenService(ILocalStorageService storageService) =>
            _storageService = storageService;

        public Task SetTokenAsync(string token)
        {
            return _storageService.SetItemAsync("token", token);
        }

        public Task<string?> GetTokenAsync()
        {
            return _storageService.GetItemAsync<string?>("token");
        }

        public async Task RemoveTokenAsync()
        {
            if (!string.IsNullOrWhiteSpace(await GetTokenAsync()))
            {
                await _storageService.RemoveItemAsync("token");
            }
        }

        public async Task<string?> GetUsernameFromExistingTokenAsync()
        {
            var token = await GetTokenAsync();

            if (string.IsNullOrWhiteSpace(token))
            {
                return token;
            }

            var tokenWrapper = new JwtSecurityToken(token);

            return tokenWrapper.Claims
                .FirstOrDefault(c => string.Equals("username", c.Type, StringComparison.CurrentCultureIgnoreCase))?
                .Value;
        }
    }
}
