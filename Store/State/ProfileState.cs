using System.Collections.Generic;
using BlazorConduit.Models.Profile;

namespace BlazorConduit.Store.State
{
    public class ProfileState : RootState
    {
        public ProfileState(bool isLoading, IEnumerable<string>? currentErrors, UserProfileDto? currentProfile)
            : base(isLoading, currentErrors)
        {
            CurrentProfile = currentProfile;
        }

        public UserProfileDto? CurrentProfile { get; }
    }
}
