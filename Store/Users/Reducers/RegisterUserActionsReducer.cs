using BlazorConduit.Store.Users.Actions.RegisterUser;
using Fluxor;

namespace BlazorConduit.Store.Users.Reducers
{
    public static class RegisterUserActionsReducer
    {
        [ReducerMethod]
        public static AppState ReduceRegisterUserAction(AppState state, RegisterUserAction action) =>
            new AppState(true, null, null, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceRegisterUserSuccessAction(AppState state, RegisterUserSuccessAction action) =>
            new AppState(false, action.User, null, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceRegisterUserFailureAction(AppState state, RegisterUserFailureAction action) =>
            new AppState(false, null, action.Errors, state.CurrentProfile);
    }
}
