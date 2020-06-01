using BlazorConduit.Models.Authentication.ViewModels;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Store
{
    public class AppState
    {
        public AppState(bool isLoading, ConduitUserViewModel? currentUser, string errorMessage) =>
            (IsLoading, CurrentUser, ErrorMessage) = (isLoading, currentUser, errorMessage);

        public bool IsLoading { get; }

        public ConduitUserViewModel? CurrentUser { get; }

        public string ErrorMessage { get; }

        public bool HasCurrentError => !string.IsNullOrWhiteSpace(ErrorMessage);

        public bool IsAuthenticated => !(CurrentUser is null);
    }
}
