using BlazorConduit.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Store.State;
using Fluxor;

namespace BlazorConduit.Store.Features.Profiles.Reducers
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
