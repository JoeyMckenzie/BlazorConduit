using BlazorConduit.Client.Models.Articles.Dtos;
using BlazorConduit.Client.Store.Features.Articles.Actions.AddComment;
using BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.DeleteArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.DeleteComment;
using BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles;
using BlazorConduit.Client.Store.Features.Articles.Actions.LoadComments;
using BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle;
using BlazorConduit.Client.Store.State;
using Fluxor;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace BlazorConduit.Client.Store.Features.Articles.Reducers
{
    public static class ArticleActionsReducer
    {
        /*
         * Create action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceCreateArticleAction(ArticleState state, CreateArticleAction _) =>
            new ArticleState(true, null, null, null, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceCreateArticleSuccessAction(ArticleState state, CreateArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, null, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceCreateArticleFailureAction(ArticleState state, CreateArticleFailureAction action) =>
            new ArticleState(false, action.Errors, null, null, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        /*
         * Retrieve action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceRetieveArticleAction(ArticleState state, RetrieveArticleAction _) =>
            new ArticleState(true, null, null, null, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceRetrieveArticleSuccessAction(ArticleState state, RetrieveArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, null, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceRetrieveArticleFailureAction(ArticleState state, RetrieveArticleFailureAction action) =>
            new ArticleState(false, action.Errors, null, null, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Get action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceGetArticlesAction(ArticleState state, GetArticlesAction action) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, null, state.CurrentCommentList, action.SearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceGetArticlesSuccessAction(ArticleState state, GetArticlesSuccessAction action) =>
            new ArticleState(false, null, state.CurrentArticle, state.IsFollowingUser, action.Articles, state.CurrentCommentList, state.CurrentSearchRequest, action.Count);

        [ReducerMethod]
        public static ArticleState ReduceGetArticlesFailureAction(ArticleState state, GetArticlesFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Update action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceUpdateArticleAction(ArticleState state, UpdateArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceUpdateArticleSuccessAction(ArticleState state, UpdateArticleSuccessAction action) =>
            new ArticleState(false, null, action.Article, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceUpdateArticleFailureAction(ArticleState state, UpdateArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Delete action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceDeleteArticleAction(ArticleState state, DeleteArticleAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceDeleteArticleSuccessAction(ArticleState state, DeleteArticleSuccessAction _) =>
            new ArticleState(false, null, null, state.IsFollowingUser, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceDeleteArticleFailureAction(ArticleState state, DeleteArticleFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Load comments action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceLoadCommentsAction(ArticleState state, LoadCommentsAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceLoadCommentsSuccessAction(ArticleState state, LoadCommentsSuccessAction action) =>
            new ArticleState(false, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, action.Comments, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceLoadCommentsFailureAction(ArticleState state, LoadCommentsFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Add comment action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceAddCommentAction(ArticleState state, AddCommentAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceAddCommentSuccessAction(ArticleState state, AddCommentSuccessAction action)
        {
            // Grab a reference to the current comment list, initialize if not available
            var currentComments = state.CurrentCommentList is null ? 
                new List<CommentDto>() :
                state.CurrentCommentList.ToList();

            // Add and order by date if there are more than one comment
            currentComments.Add(action.Comment);
            currentComments = currentComments.OrderByDescending(c => c.CreatedAt).ToList();

            return new ArticleState(false, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, currentComments, state.CurrentSearchRequest, state.TotalArticles);
        }

        [ReducerMethod]
        public static ArticleState ReduceAddCommentFailureAction(ArticleState state, AddCommentFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        /**
         * Delete comment action reducers
         */
        [ReducerMethod]
        public static ArticleState ReduceDeleteArticleState(ArticleState state, DeleteCommentAction _) =>
            new ArticleState(true, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);

        [ReducerMethod]
        public static ArticleState ReduceDeleteCommentSuccessAction(ArticleState state, DeleteCommentSuccessAction action)
        {
            // In theory, this should never happen
            if (state.CurrentCommentList is null)
            {
                return new ArticleState(false, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, null, state.CurrentSearchRequest, state.TotalArticles);
            }

            // Remove the comment and reorder the list
            var updatedCommentList = state.CurrentCommentList
                .Where(c => c.Id != action.Id)
                .OrderByDescending(c => c.CreatedAt);

            return new ArticleState(false, null, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, updatedCommentList, state.CurrentSearchRequest, state.TotalArticles);
        }

        [ReducerMethod]
        public static ArticleState ReduceDeleteCommentFailureAction(ArticleState state, DeleteCommentFailureAction action) =>
            new ArticleState(false, action.Errors, state.CurrentArticle, state.IsFollowingUser, state.CurrentArticleList, state.CurrentCommentList, state.CurrentSearchRequest, state.TotalArticles);
    }
}
