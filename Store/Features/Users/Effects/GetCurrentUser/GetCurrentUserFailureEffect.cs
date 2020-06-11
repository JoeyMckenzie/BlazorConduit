using BlazorConduit.Services;
using BlazorConduit.Store.Features.Users.Actions.GetCurrentUser;
using BlazorConduit.Store.Features.Users.Effects.LoginUser;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Features.Users.Effects.GetCurrentUser
{
    public class GetCurrentUserFailureEffect : Effect<GetCurrentUserFailureAction>
    {
        private readonly SecurityTokenService _tokenService;
        private readonly ILogger<LoginUserSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public GetCurrentUserFailureEffect(
            SecurityTokenService tokenService,
            ILogger<LoginUserSuccessEffect> logger,
            NavigationManager navigation)
        {
            _tokenService = tokenService;
            _logger = logger;
            _navigation = navigation;
        }

        protected override async Task HandleAsync(GetCurrentUserFailureAction action, IDispatcher dispatcher)
        {
            // Cache the access token in local storage, overrides if already existing
            _logger.LogInformation("Removing currently cached access token");
            await _tokenService.RemoveTokenAsync();

            // Navigate back to the home page
            _navigation.NavigateTo("/");
        }
    }
}
