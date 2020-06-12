using BlazorConduit.Client.Store.Features.Users.Actions.RegisterUser;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Users.Reducers
{
    public static class RegisterUserActionsReducer
    {
        [ReducerMethod]
        public static UserState ReduceRegisterUserAction(UserState _, RegisterUserAction __) =>
            new UserState(true, null, null);

        [ReducerMethod]
        public static UserState ReduceRegisterUserSuccessAction(UserState _, RegisterUserSuccessAction action) =>
            new UserState(false, null, action.User);

        [ReducerMethod]
        public static UserState ReduceRegisterUserFailureAction(UserState _, RegisterUserFailureAction action) =>
            new UserState(false, action.Errors, null);
    }
}
