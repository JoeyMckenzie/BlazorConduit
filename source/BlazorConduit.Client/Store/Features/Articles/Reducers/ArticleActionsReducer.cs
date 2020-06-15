using BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle;
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
        public static ArticleState ReduceCreateArticleAction(ArticleState _, CreateArticleAction __) =>
            new ArticleState(true, null, null);

        [ReducerMethod]
        public static ArticleState ReduceCreateArticleSuccessAction(ArticleState _, CreateArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article);

        [ReducerMethod]
        public static ArticleState ReduceCreateArticleFailureAction(ArticleState _, CreateArticleFailureAction action) =>
            new ArticleState(false, action.Errors, null);

        /*
         * Retrieve action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceRetieveArticleAction(ArticleState _, RetrieveArticleAction __) =>
            new ArticleState(true, null, null);

        [ReducerMethod]
        public static ArticleState ReduceRetrieveArticleSuccessAction(ArticleState _, RetrieveArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article);

        [ReducerMethod]
        public static ArticleState ReduceRetrieveArticleFailureAction(ArticleState _, RetrieveArticleFailureAction action) =>
            new ArticleState(false, action.Errors, null);
    }
}
