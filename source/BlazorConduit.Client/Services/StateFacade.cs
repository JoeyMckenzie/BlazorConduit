using BlazorConduit.Client.Models.Authentication.Requests;
using Fluxor;
using Microsoft.Extensions.Logging;
using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Client.Store.Features.Users.Actions.GetCurrentUser;
using BlazorConduit.Client.Store.Features.Users.Actions.LoginUser;
using BlazorConduit.Client.Store.Features.Users.Actions.RegisterUser;
using BlazorConduit.Client.Store.Features.Users.Actions.UpdateUser;
using BlazorConduit.Client.Models.Articles.Requests;
using BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.FollowUserFromArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.UnfollowUserFromArticle;
using BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUserFromProfile;
using BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUserFromProfile;
using BlazorConduit.Client.Store.Features.Articles.Actions.FavoritePostFromArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.UnfavoritePostFromArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles;
using BlazorConduit.Client.Models.Articles.Dtos;
using BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.DeleteArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.AddComment;
using BlazorConduit.Client.Store.Features.Articles.Actions.DeleteComment;
using BlazorConduit.Client.Store.Features.Tags.Actions.GetTags;
using BlazorConduit.Client.Services.Contracts;

namespace BlazorConduit.Client.Services
{
    public class StateFacade : IStateFacade
    {
        private readonly IDispatcher _dispatcher;
        private readonly ILogger<StateFacade> _logger;

        public StateFacade(IDispatcher dispatcher, ILogger<StateFacade> logger) =>
            (_dispatcher, _logger) = (dispatcher, logger);

        /*
         * Authentication actions
         */
        public void RegisterUser(RegisterUserRequest request)
        {
            _logger.LogInformation($"Dispatching user registration request for user email {request.User.Email}");
            _dispatcher.Dispatch(new RegisterUserAction(request));
        }

        public void LoginUser(LoginUserRequest request)
        {
            _logger.LogInformation($"Dispatching user login request for user email {request.User.Email}");
            _dispatcher.Dispatch(new LoginUserAction(request));
        }

        public void UpdateUser(UpdateUserRequest request)
        {
            _logger.LogInformation($"Dispatching user update request for user email {request.User?.Email}");
            _dispatcher.Dispatch(new UpdateUserAction(request));
        }

        public void GetCurrentUser(string? token = null)
        {
            _logger.LogInformation($"Retrieving current user from cached token");
            _dispatcher.Dispatch(new GetCurrentUserAction(token));
        }

        /**
         * Profile actions
         */
        public void GetUserProfile(string username)
        {
            _logger.LogInformation($"Loading user profile for {username}");
            _dispatcher.Dispatch(new LoadUserProfileAction(username));
        }

        public void FollowUserProfile(string username)
        {
            _logger.LogInformation($"Following user profile {username}");
            _dispatcher.Dispatch(new FollowUserFromProfileAction(username));
        }

        public void UnfollowUserProfile(string username)
        {
            _logger.LogInformation($"Unfollowing user profile {username}");
            _dispatcher.Dispatch(new UnfollowUserFromProfileAction(username));
        }

        /**
         * Article actions
         */
        public void CreateArticle(CreateArticleRequest request)
        {
            _logger.LogInformation($"Creating article {request.Article.Title}");
            _dispatcher.Dispatch(new CreateArticleAction(request));
        }

        public void RetrieveArticle(string slug, bool loadComments = true)
        {
            _logger.LogInformation($"Retrieving article {slug}");
            _dispatcher.Dispatch(new RetrieveArticleAction(slug, loadComments));
        }

        public void UpdateArticle(UpdateArticleDto article)
        {
            _logger.LogInformation($"Updating article {article.Slug}");
            _dispatcher.Dispatch(new UpdateArticleAction(article));
        }

        public void DeleteArticle(string slug)
        {
            _logger.LogInformation($"Deleting article {slug}");
            _dispatcher.Dispatch(new DeleteArticleAction(slug));
        }

        public void AddComment(CreateCommentRequest comment, string slug)
        {
            _logger.LogInformation($"Adding comment to article {slug}");
            _dispatcher.Dispatch(new AddCommentAction(comment, slug));
        }

        public void DeleteComment(int id, string slug)
        {
            _logger.LogInformation($"Removing comment ID {id} from article {slug}");
            _dispatcher.Dispatch(new DeleteCommentAction(id, slug));
        }

        public void GetArticles(
            string? tag = null,
            string? author = null,
            string? favorited = null,
            int? limit = null,
            int? offset = null)
        {
            _logger.LogInformation("Retrieving articles");
            var searchRequest = new ArticleSearchRequest(limit.GetValueOrDefault(10), offset.GetValueOrDefault(0), author, favorited, tag);
            _dispatcher.Dispatch(new GetArticlesAction(searchRequest));
        }

        public void GetFeed(
            string? tag = null,
            string? author = null,
            string? favorited = null,
            int? limit = null,
            int? offset = null)
        {
            _logger.LogInformation("Retrieving articles");
            var searchRequest = new ArticleSearchRequest(limit.GetValueOrDefault(10), offset.GetValueOrDefault(0), author, favorited, tag);
            _dispatcher.Dispatch(new GetArticlesAction(searchRequest, true));
        }

        public void FollowUserFromArticle(string username)
        {
            _logger.LogInformation($"Following user from article page {username}");
            _dispatcher.Dispatch(new FollowUserFromArticleAction(username));
        }

        public void UnfollowUserFromArticle(string username)
        {
            _logger.LogInformation($"Unfollowing user from article page {username}");
            _dispatcher.Dispatch(new UnfollowUserFromArticleAction(username));
        }

        public void FavoritePostFromArticle(string slug)
        {
            _logger.LogInformation($"Favoriting article {slug}");
            _dispatcher.Dispatch(new FavoritePostFromArticleAction(slug));
        }

        public void UnfavoritePostFromArticle(string slug)
        {
            _logger.LogInformation($"Unfavoriting article {slug}");
            _dispatcher.Dispatch(new UnfavoritePostFromArticleAction(slug));
        }

        /**
         * Tag actions
         */
        public void LoadTags()
        {
            _logger.LogInformation("Loading tags from API");
            _dispatcher.Dispatch(new GetTagsAction());
        }
    }
}
