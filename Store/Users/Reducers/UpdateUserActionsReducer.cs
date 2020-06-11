using BlazorConduit.Store.Users.Actions.UpdateUser;
using Fluxor;

namespace BlazorConduit.Store.Users.Reducers
{
    public static class UpdateUserActionsReducer
    {
        [ReducerMethod]
        public static AppState ReduceUpdateUserAction(AppState state, UpdateUserAction action) =>
            new AppState(true, state.CurrentUser, state.CurrentErrors, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceUpdateUserSuccessAction(AppState state, UpdateUserSuccessAction action) =>
            new AppState(false, action.User, null, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceUpdateUserFailureAction(AppState state, UpdateUserFailureAction action) =>
            new AppState(false, state.CurrentUser, action.Errors, state.CurrentProfile);
    }
}
