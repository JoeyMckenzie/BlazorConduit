using BlazorConduit.Client.Models.Authentication.Dtos;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.State
{
    public class UserState : RootState
    {
        public UserState(bool isLoading, IEnumerable<string>? errors, ConduitUserDto? currentUser)
            : base(isLoading, errors) => CurrentUser = currentUser;

        public ConduitUserDto? CurrentUser { get; }

        public bool IsAuthenticated => !(CurrentUser is null);

        public static UserState FromInitialState() =>
            new UserState(false, null, null);
    }
}
