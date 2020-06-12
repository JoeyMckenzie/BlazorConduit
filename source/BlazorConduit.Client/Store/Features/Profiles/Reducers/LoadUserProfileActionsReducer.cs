using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Profiles.Reducers
{
    public static class LoadUserProfileActionsReducer
    {
        [ReducerMethod]
        public static ProfileState ReduceLoadUserProfileAction(ProfileState _, LoadUserProfileAction __) =>
            new ProfileState(true, null, null);

        [ReducerMethod]
        public static ProfileState ReduceLoadUserProfileSuccessAction(ProfileState _, LoadUserProfileSuccessAction action) =>
            new ProfileState(false, null, action.Profile);
    }
}
