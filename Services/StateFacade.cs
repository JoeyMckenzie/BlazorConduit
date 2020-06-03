using BlazorConduit.Models.Authentication.Requests;
using BlazorConduit.Store.Users.Actions.LoginUser;
using BlazorConduit.Store.Users.Actions.RegisterUser;
using Fluxor;
using Microsoft.Extensions.Logging;

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
    }
}
