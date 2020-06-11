using BlazorConduit.Store.Users.Actions.LoadUserProfile;
using Fluxor;

namespace BlazorConduit.Store.Users.Reducers
{
    public static class LoadUserProfileActionsReducer
    {
        [ReducerMethod]
        public static AppState ReduceLoadUserProfileAction(AppState state, LoadUserProfileAction _) =>
            new AppState(true, state.CurrentUser, null, state.CurrentProfile);

        [ReducerMethod]
        public static AppState ReduceLoadUserProfileSuccessAction(AppState state, LoadUserProfileSuccessAction action) =>
            new AppState(false, state.CurrentUser, null, action.LoadMemoryCachedProfile ? state.CurrentProfile : action.Profile);
    }
}
