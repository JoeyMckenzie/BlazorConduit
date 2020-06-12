using BlazorConduit.Client.Store.Features.Users.Actions.GetCurrentUser;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Users.Reducers
{
    public static class GetCurrentUserActionsReducer
    {
        [ReducerMethod]
        public static UserState ReduceGetCurrentUserAction(UserState state, GetCurrentUserAction _) =>
            new UserState(true, state.CurrentErrors, state.CurrentUser);

        [ReducerMethod]
        public static UserState ReduceGetCurrentUserSuccsessAction(UserState _, GetCurrentUserSuccessAction action) =>
            new UserState(false, null, action.User);

        [ReducerMethod]
        public static UserState ReduceGetCurrentUserFailureAction(UserState state, GetCurrentUserFailureAction action) =>
            new UserState(false, action.Errors, state.CurrentUser);
    }
}
