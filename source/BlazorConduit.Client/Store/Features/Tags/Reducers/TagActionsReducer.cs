using BlazorConduit.Client.Store.Features.Tags.Actions.GetTags;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Tags.Reducers
{
    public static class TagActionsReducer
    {
        [ReducerMethod]
        public static TagState ReduceGetTagsAction(TagState _, GetTagsAction __) =>
            new TagState(true, null, null);

        [ReducerMethod]
        public static TagState ReduceGetTagsSuccessAction(TagState _, GetTagsSuccessAction action) =>
            new TagState(false, null, action.Tags);

        [ReducerMethod]
        public static TagState ReduceGetTagsAction(TagState _, GetTagsFailureAction action) =>
            new TagState(false, action.Errors, null);
    }
}
