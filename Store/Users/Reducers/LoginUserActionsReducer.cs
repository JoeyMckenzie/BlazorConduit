using BlazorConduit.Store.Users.Actions.LoginUser;
using Fluxor;

namespace BlazorConduit.Store.Users.Reducers
{
    public static class LoginUserActionsReducer
    {
        [ReducerMethod]
        public static AppState ReduceLoginUserAction(AppState state, LoginUserAction action) =>
            new AppState(true, null, null, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceLoginUserSuccessAction(AppState state, LoginUserSuccessAction action) =>
            new AppState(false, action.User, null, state.CurrentProfile);
        [ReducerMethod]

        public static AppState ReduceLoginUserFailureAction(AppState state, LoginUserFailureAction action) =>
            new AppState(false, null, action.Errors, state.CurrentProfile);

    }
}
