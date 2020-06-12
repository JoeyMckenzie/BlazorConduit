using BlazorConduit.Models.Authentication.Dtos;
using BlazorConduit.Models.Profile;
using System.Collections.Generic;
using System.Linq;

namespace BlazorConduit.Store.State
{
    public class AppState
    {
        public AppState(bool isLoading, ConduitUserDto? currentUser, IEnumerable<string>? currentErrors, UserProfileDtcurrentProfile) =>
            (IsLoading, CurrentUser, CurrentErrors) = (isLoading, currentUser, currentErrors, currentProfile);

        public bool IsLoading { get; }

        public ConduitUserDto? CurrentUser { get; }

        public IEnumerable<string>? CurrentErrors { get; }

        public bool HasCurrentErrors => !(CurrentErrors is null) && CurrentErrors.Any();

        public bool IsAuthenticated => !(CurrentUser is null);

        public static AppState FromInitialState() =>
            new AppState(false, null, null, null);
    }
}
