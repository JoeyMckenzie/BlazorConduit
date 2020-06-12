using BlazorConduit.Client.Models.Profiles;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile
{
    public class LoadUserProfileSuccessAction
    {
        public LoadUserProfileSuccessAction(UserProfileDto profile) =>
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
