using BlazorConduit.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Store.State;
using Fluxor;

namespace BlazorConduit.Store.Features.Profiles.Reducers
{
    public static class LoadUserProfileActionsReducer
    {
        [ReducerMethod]
        public static ProfileState ReduceLoadUserProfileAction(ProfileState _, LoadUserProfileAction __) =>
            new ProfileState(true, null, null);

        [ReducerMethod]
        public static ProfileState ReduceLoadUserProfileSuccessAction(ProfileState state, LoadUserProfileSuccessAction action) =>
            new ProfileState(false, null, action.LoadMemoryCachedProfile ? state.CurrentProfile : action.Profile);
    }
}
