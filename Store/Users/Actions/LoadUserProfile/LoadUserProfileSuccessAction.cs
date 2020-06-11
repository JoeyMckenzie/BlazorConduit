using BlazorConduit.Models.Profile;

namespace BlazorConduit.Store.Users.Actions.LoadUserProfile
{
    public class LoadUserProfileSuccessAction
    {
        public LoadUserProfileSuccessAction(UserProfileDto profile, bool loadMemoryCachedProfile = false) =>
            (Profile, LoadMemoryCachedProfile) = (profile, loadMemoryCachedProfile);

        public UserProfileDto Profile { get; }

        public bool LoadMemoryCachedProfile { get; }
    }
}
