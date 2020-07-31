using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.State;
using Blazored.LocalStorage;
using Fluxor;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Services
{
    public class SecurityTokenService : ITokenService
    {
        private readonly ILocalStorageService _storageService;
        private readonly IState<UserState> _state;

        public SecurityTokenService(ILocalStorageService storageService, IState<UserState> state) =>
            (_storageService, _state) = (storageService, state);

        public Task SetTokenAsync(string token) =>
            _storageService.SetItemAsync("token", token);

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
