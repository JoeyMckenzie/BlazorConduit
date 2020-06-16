using BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles;
using BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle;
using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Articles.Reducers
{
    public static class ArticleActionsReducer
    {
        /*
         * Create action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceCreateArticleAction(ArticleState state, CreateArticleAction _) =>
            new ArticleState(true, null, null, null, state.CurrentArticleList);

        [ReducerMethod]
        public static ArticleState ReduceCreateArticleSuccessAction(ArticleState state, CreateArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, null, state.CurrentArticleList);

        [ReducerMethod]
        public static ArticleState ReduceCreateArticleFailureAction(ArticleState state, CreateArticleFailureAction action) =>
            new ArticleState(false, action.Errors, null, null, state.CurrentArticleList);

        /*
         * Retrieve action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceRetieveArticleAction(ArticleState state, RetrieveArticleAction __) =>
            new ArticleState(true, null, null, null, state.CurrentArticleList);

        [ReducerMethod]
        public static ArticleState ReduceRetrieveArticleSuccessAction(ArticleState state, RetrieveArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, null, state.CurrentArticleList);

        [ReducerMethod]
        public static ArticleState ReduceRetrieveArticleFailureAction(ArticleState state, RetrieveArticleFailureAction action) =>
            new ArticleState(false, action.Errors, null, null, state.CurrentArticleList);

        /**
         * Get action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceGetArticlesAction(ArticleState state, GetArticlesAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, null);

        [ReducerMethod]
        public static ArticleState ReduceGetArticlesSuccessAction(ArticleState state, GetArticlesSuccessAction action) =>
            new ArticleState(false, null, state.CurrentArticle, state.IsFollowingUser, action.Articles);

        [ReducerMethod]
        public static ArticleState ReduceGetArticlesFailureAction(ArticleState state, GetArticlesFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList);

        /**
         * Update action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceUpdateArticleAction(ArticleState state, UpdateArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList);

        [ReducerMethod]
        public static ArticleState ReduceUpdateArticleSuccessAction(ArticleState state, UpdateArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, state.IsFollowingUser, state.CurrentArticleList);

        [ReducerMethod]
        public static ArticleState ReduceUpdateArticleFailureAction(ArticleState state, UpdateArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList);
    }
}
