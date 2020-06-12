using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Profiles.Effects.LoadUserProfile
{
    public class LoadUserProfileFailureEffect : Effect<LoadUserProfileFailureAction>
    {
        private readonly ILogger<LoadUserProfileFailureEffect> _logger;
        private readonly NavigationManager _navigation;

        public LoadUserProfileFailureEffect(ILogger<LoadUserProfileFailureEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(LoadUserProfileFailureAction action, IDispatcher dispatcher)
        {
            _logger.LogWarning("Error loading user profile, navigating to home");
            _navigation.NavigateTo("/");

            return Task.CompletedTask;
        }
    }
}
