using BlazorConduit.Models.Authentication.Dtos;
using BlazorConduit.Models.Authentication.ViewModels;
using BlazorConduit.Models.Common.ViewModels;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Store
{
    public class AppState
    {
        public AppState(bool isLoading, ConduitUserDto? currentUser, IEnumerable<string>? currentErrors) =>
            (IsLoading, CurrentUser, CurrentErrors) = (isLoading, currentUser, currentErrors);

        public bool IsLoading { get; }

        public ConduitUserDto? CurrentUser { get; }

        public IEnumerable<string>? CurrentErrors { get; }

        public bool HasCurrentErrors => !(CurrentErrors is null) && CurrentErrors.Any();

        public bool IsAuthenticated => !(CurrentUser is null);
    }
}
