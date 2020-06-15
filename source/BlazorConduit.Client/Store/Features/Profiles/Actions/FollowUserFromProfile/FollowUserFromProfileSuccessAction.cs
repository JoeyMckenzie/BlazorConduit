using BlazorConduit.Client.Models.Profiles;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUserFromProfile
{
    public class FollowUserFromProfileSuccessAction
    {
        public FollowUserFromProfileSuccessAction(UserProfileDto profile) =>
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
