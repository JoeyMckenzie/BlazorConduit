using BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUserFromProfile;
using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using Fluxor;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Profiles.Effects.FollowUserFromProfile
{
    public class FollowUserSuccessEffect : Effect<FollowUserFromProfileSuccessAction>
    {
        private readonly ILogger<FollowUserSuccessEffect> _logger;

        public FollowUserSuccessEffect(ILogger<FollowUserSuccessEffect> logger) =>
            _logger = logger;

        protected override Task HandleAsync(FollowUserFromProfileSuccessAction action, IDispatcher dispatcher)
        {
            // Reload the user profile on a successful follow
            _logger.LogInformation($"Successfully followed user {action.Profile.Username}, refreshing profile...");
            dispatcher.Dispatch(new SetUserProfileAction(action.Profile));

            return Task.CompletedTask;
        }
    }
}
