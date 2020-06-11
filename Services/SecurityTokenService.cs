using BlazorConduit.Store.State;
using Blazored.LocalStorage;
using Fluxor;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Services
{
    public class SecurityTokenService
    {
        private readonly ILocalStorageService _storageService;
        private readonly IState<AppState> _state;

        public SecurityTokenService(ILocalStorageService storageService, IState<AppState> state) =>
            (_storageService, _state) = (storageService, state);

        public Task SetTokenAsync(string token)
        {
            return _storageService.SetItemAsync("token", token);
        }

        public Task<string?> GetTokenAsync()
        {
            // If the token exists in the current user state value, return it
            if (_state.Value.IsAuthenticated)
            {
                return Task.FromResult(_state.Value.CurrentUser!.Token);
            }

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
