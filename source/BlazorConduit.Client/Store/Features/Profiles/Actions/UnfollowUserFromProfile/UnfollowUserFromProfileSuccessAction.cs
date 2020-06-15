using BlazorConduit.Client.Models.Profiles;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUserFromProfile
{
    public class UnfollowUserFromProfileSuccessAction
    {
        public UnfollowUserFromProfileSuccessAction(UserProfileDto profile) =>
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
