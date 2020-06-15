using BlazorConduit.Client.Models.Profiles;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile
{
    public class SetUserProfileAction
    {
        public SetUserProfileAction(UserProfileDto profile) =>
            Profile = profile;

        public UserProfileDto Profile { get; }
    }
}
