using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Profiles.Effects.LoadUserProfile
{
    public class LoadUserProfileSuccessEffect : Effect<LoadUserProfileSuccessAction>
    {
        private readonly ILogger<LoadUserProfileSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public LoadUserProfileSuccessEffect(ILogger<LoadUserProfileSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(LoadUserProfileSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation($"Navigating to user profile {action.Profile.Username}");
            _navigation.NavigateTo($"/profile/{action.Profile.Username}");

            return Task.CompletedTask;
        }
    }
}
