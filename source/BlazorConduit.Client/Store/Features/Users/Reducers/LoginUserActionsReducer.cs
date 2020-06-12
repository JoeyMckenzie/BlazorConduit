using BlazorConduit.Client.Store.Features.Users.Actions.LoginUser;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Users.Reducers
{
    public static class LoginUserActionsReducer
    {
        [ReducerMethod]
        public static UserState ReduceLoginUserAction(UserState _, LoginUserAction __) =>
            new UserState(true, null, null);

        [ReducerMethod]
        public static UserState ReduceLoginUserSuccessAction(UserState _, LoginUserSuccessAction action) =>
            new UserState(false, null, action.User);
        [ReducerMethod]

        public static UserState ReduceLoginUserFailureAction(UserState _, LoginUserFailureAction action) =>
            new UserState(false, action.Errors, null);

    }
}
