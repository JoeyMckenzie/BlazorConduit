using BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUserFromProfile;
using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUserFromProfile;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Profiles.Reducers
{
    public static class UserProfileActionsReducer
    {
        [ReducerMethod]
        public static ProfileState ReduceFollowUserAction(ProfileState state, FollowUserFromProfileAction _) =>
            new ProfileState(true, null, state.CurrentProfile);

        [ReducerMethod]
        public static ProfileState ReduceFollowUserSuccessAction(ProfileState _, FollowUserFromProfileSuccessAction action) =>
            new ProfileState(false, null, action.Profile);

        [ReducerMethod]
        public static ProfileState ReduceFollowUserFailureAction(ProfileState state, FollowUserFromProfileFailureAction action) =>
            new ProfileState(false, action.Errors, state.CurrentProfile);

        [ReducerMethod]
        public static ProfileState ReduceUnfollowUserAction(ProfileState state, UnfollowUserFromProfileAction _) =>
            new ProfileState(true, null, state.CurrentProfile);

        [ReducerMethod]
        public static ProfileState ReduceUnfollowUserSuccessAction(ProfileState _, UnfollowUserFromProfileSuccessAction action) =>
            new ProfileState(false, null, action.Profile);

        [ReducerMethod]
        public static ProfileState ReduceUnfollowUserFailureAction(ProfileState state, UnfollowUserFromProfileFailureAction action) =>
            new ProfileState(false, action.Errors, state.CurrentProfile);

        [ReducerMethod]
        public static ProfileState ReduceSetUserProfileAction(ProfileState state, SetUserProfileAction action) =>
            new ProfileState(state.IsLoading, state.CurrentErrors, action.Profile);
    }
}
