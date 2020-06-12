using BlazorConduit.Client.Models.Profile;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUser
{
    public class UnfollowUserSuccessAction
    {
        public UnfollowUserSuccessAction(UserProfileDto profile) =>
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
