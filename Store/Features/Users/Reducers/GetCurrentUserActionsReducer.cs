using BlazorConduit.Store.Features.Users.Actions.GetCurrentUser;
using BlazorConduit.Store.State;
using Fluxor;

namespace BlazorConduit.Store.Features.Users.Reducers
{
    public static class GetCurrentUserActionsReducer
    {
        [ReducerMethod]
        public static AppState ReduceGetCurrentUserAction(AppState state, GetCurrentUserAction action) =>
            new AppState(true, state.CurrentUser, state.CurrentErrors, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceGetCurrentUserSuccsessAction(AppState state, GetCurrentUserSuccessAction action) =>
            new AppState(false, action.User, null, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceGetCurrentUserFailureAction(AppState state, GetCurrentUserFailureAction action) =>
            new AppState(false, state.CurrentUser, action.Errors, state.CurrentProfile);
    }
}
