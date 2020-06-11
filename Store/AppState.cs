using BlazorConduit.Models.Authentication.Dtos;
using BlazorConduit.Models.Authentication.ViewModels;
using BlazorConduit.Models.Common.ViewModels;
using BlazorConduit.Models.Profile;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Store
{
    public class AppState
    {
        public AppState(bool isLoading, ConduitUserDto? currentUser, IEnumerable<string>? currentErrors, UserProfileDto? currentProfile) =>
            (IsLoading, CurrentUser, CurrentErrors, CurrentProfile) = (isLoading, currentUser, currentErrors, currentProfile);

        public bool IsLoading { get; }

        public ConduitUserDto? CurrentUser { get; }

        public IEnumerable<string>? CurrentErrors { get; }

        public UserProfileDto? CurrentProfile { get; }

        public bool HasCurrentErrors => !(CurrentErrors is null) && CurrentErrors.Any();

        public bool IsAuthenticated => !(CurrentUser is null);
    }
}
