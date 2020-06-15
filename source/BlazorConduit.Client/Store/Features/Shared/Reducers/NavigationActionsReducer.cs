using BlazorConduit.Client.Store.State;
using Fluxor;
using Fluxor.Blazor.Web.Middlewares.Routing;

namespace BlazorConduit.Client.Store.Features.Shared.Reducers
{
    public static class NavigationActionsReducer
    {
        /// <summary>
        /// On page navigation, clear all errors from the user state so API errors will not persist across login and register pages.
        /// </summary>
        /// <param name="state">Current user state.</param>
        /// <param name="action">Fluxor navigation action issued on each routing call.</param>
        /// <returns>New user state with errors cleared.</returns>
        [ReducerMethod]
        public static UserState ReduceNavigationGoAction(UserState state, GoAction _) =>
            new UserState(state.IsLoading, null, state.CurrentUser);
    }
}
