using BlazorConduit.Models.Authentication.Requests;
using Fluxor;
using Microsoft.Extensions.Logging;
using BlazorConduit.Store.Features.Profiles.Actions.LoadUserProfile;
using BlazorConduit.Store.Features.Users.Actions.GetCurrentUser;
using BlazorConduit.Store.Features.Users.Actions.LoginUser;
using BlazorConduit.Store.Features.Users.Actions.RegisterUser;
using BlazorConduit.Store.Features.Users.Actions.UpdateUser;

namespace BlazorConduit.Services
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
    }
}
