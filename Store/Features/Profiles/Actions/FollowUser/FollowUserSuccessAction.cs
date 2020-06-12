using BlazorConduit.Models.Profile;

namespace BlazorConduit.Store.Features.Profiles.Actions.FollowUser
{
    public class FollowUserSuccessAction
    {
        public FollowUserSuccessAction(UserProfileDto profile) => 
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
