using BlazorConduit.Client.Models.Profile;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUser
{
    public class FollowUserSuccessAction
    {
        public FollowUserSuccessAction(UserProfileDto profile) => 
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
