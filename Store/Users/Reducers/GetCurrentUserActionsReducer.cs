using BlazorConduit.Store.Users.Actions.GetCurrentUser;
using Fluxor;

namespace BlazorConduit.Store.Users.Reducers
{
    public static class GetCurrentUserActionsReducer
    {
        [ReducerMethod]
        public static AppState ReduceGetCurrentUserAction(AppState state, GetCurrentUserAction action) =>
            new AppState(true, state.CurrentUser, state.CurrentErrors);

        [ReducerMethod]
        public static AppState ReduceGetCurrentUserSuccsessAction(AppState state, GetCurrentUserSuccessAction action) =>
            new AppState(false, action.User, null);

        [ReducerMethod]
        public static AppState ReduceGetCurrentUserFailureAction(AppState state, GetCurrentUserFailureAction action) =>
            new AppState(false, state.CurrentUser, action.Errors);
    }
}
