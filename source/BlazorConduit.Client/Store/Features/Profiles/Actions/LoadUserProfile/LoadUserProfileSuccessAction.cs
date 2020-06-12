using BlazorConduit.Client.Models.Profile;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile
{
    public class LoadUserProfileSuccessAction
    {
        public LoadUserProfileSuccessAction(UserProfileDto profile, bool loadMemoryCachedProfile = false) =>
            (Profile, LoadMemoryCachedProfile) = (profile, loadMemoryCachedProfile);

        public UserProfileDto Profile { get; }

        public bool LoadMemoryCachedProfile { get; }
    }
}
