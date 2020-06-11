using BlazorConduit.Models.Profile;

namespace BlazorConduit.Store.Users.Actions.LoadUserProfile
{
    public class LoadUserProfileSuccessAction
    {
        public LoadUserProfileSuccessAction(UserProfileDto profile) =>
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
