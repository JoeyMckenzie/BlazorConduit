using BlazorConduit.Client.Models.Authentication.Requests;
using Fluxor;
using Microsoft.Extensions.Logging;
using BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Client.Store.Features.Users.Actions.GetCurrentUser;
using BlazorConduit.Client.Store.Features.Users.Actions.LoginUser;
using BlazorConduit.Client.Store.Features.Users.Actions.RegisterUser;
using BlazorConduit.Client.Store.Features.Users.Actions.UpdateUser;
using BlazorConduit.Client.Store.Profiles.Actions.FollowUser;
using BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUser;
using BlazorConduit.Client.Models.Articles.Requests;
using BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle;
using BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle;
using BlazorConduit.Client.Store.Features.Shared.Reducers;

namespace BlazorConduit.Client.Services
{
    public class StateFacade
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
            _dispatcher.Dispatch(new FollowUserAction(username));
        }

        public void UnfollowUserProfile(string username)
        {
            _logger.LogInformation($"Unfollowing user profile {username}");
            _dispatcher.Dispatch(new UnfollowUserAction(username));
        }

        /**
         * Article actions
         */
        public void CreateArticle(CreateArticleRequest request)
        {
            _logger.LogInformation($"Creating article {request.Article.Title}");
            _dispatcher.Dispatch(new CreateArticleAction(request));
        }

        public void RetrieveArticle(string slug)
        {
            _logger.LogInformation($"Retrieving article {slug}");
            _dispatcher.Dispatch(new RetrieveArticleAction(slug));
        }
    }
}
