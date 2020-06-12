using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUser;
using Fluxor;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Profiles.Effects.UnfollowUser
{
    public class UnfollowUserSuccessEffect : Effect<UnfollowUserSuccessAction>
    {
        private readonly ILogger<UnfollowUserSuccessEffect> _logger;

        public UnfollowUserSuccessEffect(ILogger<UnfollowUserSuccessEffect> logger) =>
            _logger = logger;

        protected override Task HandleAsync(UnfollowUserSuccessAction action, IDispatcher dispatcher)
        {
            // Reload the user profile on a successful follow
            _logger.LogInformation($"Successfully unfollowed user {action.Profile.Username}, refreshing profile...");
            dispatcher.Dispatch(new LoadUserProfileSuccessAction(action.Profile));

            return Task.CompletedTask;
        }
    }
}
