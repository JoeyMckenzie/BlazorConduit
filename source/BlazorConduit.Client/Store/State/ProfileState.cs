using System.Collections.Generic;
using BlazorConduit.Client.Models.Profile;

namespace BlazorConduit.Client.Store.State
{
    public class ProfileState : RootState<ProfileState>
    {
        public ProfileState(bool isLoading, IEnumerable<string>? currentErrors, UserProfileDto? currentProfile)
            : base(isLoading, currentErrors)
        {
            CurrentProfile = currentProfile;
        }

        public UserProfileDto? CurrentProfile { get; }

        public bool HasCachedProfile => !(CurrentProfile is null);

        public static ProfileState FromInitialState() =>
            new ProfileState(false, null, null);
    }
}
