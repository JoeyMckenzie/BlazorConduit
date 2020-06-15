using BlazorConduit.Client.Store.Features.Articles.Actions.FollowUserFromArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.UnfollowUserFromArticle;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Articles.Reducers
{
    public static class UserArticleActionsReducer
    {
        /**
         * Follow action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceFollowUserFromArticleAction(ArticleState state, FollowUserFromArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser);

        [ReducerMethod]
        public static ArticleState ReduceFollowUserFromArticleSuccessAction(ArticleState state, FollowUserFromArticleSuccessAction action) =>
            new ArticleState(false, null, state.CurrentArticle, true);

        [ReducerMethod]
        public static ArticleState ReduceFollowUserFromArticleFailureAction(ArticleState state, FollowUserFromArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser);

        /**
         * Unfollow action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceUnfollowUserFromArticleAction(ArticleState state, UnfollowUserFromArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser);

        [ReducerMethod]
        public static ArticleState ReduceUnfollowUserFromArticleSuccessAction(ArticleState state, UnfollowUserFromArticleSuccessAction action) =>
            new ArticleState(false, null, state.CurrentArticle, false);

        [ReducerMethod]
        public static ArticleState ReduceUnfollowUserFromArticleFailureAction(ArticleState state, UnfollowUserFromArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser);

    }
}
