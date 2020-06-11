using BlazorConduit.Store.Users.Actions.LoadUserProfile;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Users.Effects.LoadUserProfile
{
    public class LoadUserProfileSuccessEffect : Effect<LoadUserProfileSuccessAction>
    {
        private ILogger<LoadUserProfileSuccessEffect> _logger;
        private NavigationManager _navigation;

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
