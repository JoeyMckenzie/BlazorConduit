using BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUser;
using BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUser;
using BlazorConduit.Client.Store.Profiles.Actions.FollowUser;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Profiles.Reducers
{
    public static class UserProfileActionsReducer
    {
        [ReducerMethod]
        public static ProfileState ReduceFollowUserAction(ProfileState state, FollowUserAction _) =>
            new ProfileState(true, null, state.CurrentProfile);

        [ReducerMethod]
        public static ProfileState ReduceFollowUserSuccessAction(ProfileState _, FollowUserSuccessAction action) =>
            new ProfileState(false, null, action.Profile);

        [ReducerMethod]
        public static ProfileState ReduceFollowUserFailureAction(ProfileState state, FollowUserFailureAction action) =>
            new ProfileState(false, action.Errors, state.CurrentProfile);

        [ReducerMethod]
        public static ProfileState ReduceUnfollowUserAction(ProfileState state, UnfollowUserAction _) =>
            new ProfileState(true, null, state.CurrentProfile);

        [ReducerMethod]
        public static ProfileState ReduceUnfollowUserSuccessAction(ProfileState _, UnfollowUserSuccessAction action) =>
            new ProfileState(false, null, action.Profile);

        [ReducerMethod]
        public static ProfileState ReduceUnfollowUserFailureAction(ProfileState state, UnfollowUserFailureAction action) =>
            new ProfileState(false, action.Errors, state.CurrentProfile);
    }
}
