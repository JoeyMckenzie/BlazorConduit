using BlazorConduit.Client.Store.Features.Articles.Actions.FavoritePostFromArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.FollowUserFromArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.UnfavoritePostFromArticle;
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
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceFollowUserFromArticleSuccessAction(ArticleState state, FollowUserFromArticleSuccessAction _) =>
            new ArticleState(false, null, state.CurrentArticle, true, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceFollowUserFromArticleFailureAction(ArticleState state, FollowUserFromArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Unfollow action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceUnfollowUserFromArticleAction(ArticleState state, UnfollowUserFromArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceUnfollowUserFromArticleSuccessAction(ArticleState state, UnfollowUserFromArticleSuccessAction _) =>
            new ArticleState(false, null, state.CurrentArticle, false, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceUnfollowUserFromArticleFailureAction(ArticleState state, UnfollowUserFromArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Favorite post action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceFavoritePostFromArticle(ArticleState state, FavoritePostFromArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceFavoritePostFromSuccessArticle(ArticleState state, FavoritePostFromArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceFavoritePostFromFailureArticle(ArticleState state, FavoritePostFromArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Unfavorite post action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceUnfavoritePostFromArticle(ArticleState state, UnfavoritePostFromArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceUnfavoritePostFromSuccessArticle(ArticleState state, UnfavoritePostFromArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceUnfavoritePostFromFailureArticle(ArticleState state, UnfavoritePostFromArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);
    }
}
