using BlazorConduit.Client.Store.Features.Users.Actions.UpdateUser;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Users.Reducers
{
    public static class UpdateUserActionsReducer
    {
        [ReducerMethod]
        public static UserState ReduceUpdateUserAction(UserState state, UpdateUserAction _) =>
            new UserState(true, null, state.CurrentUser);

        [ReducerMethod]
        public static UserState ReduceUpdateUserSuccessAction(UserState _, UpdateUserSuccessAction action) =>
            new UserState(false, null, action.User);

        [ReducerMethod]
        public static UserState ReduceUpdateUserFailureAction(UserState state, UpdateUserFailureAction action) =>
            new UserState(false, action.Errors, state.CurrentUser);
    }
}
