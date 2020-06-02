using BlazorConduit.Models.Authentication.RequestModels;
using BlazorConduit.Store.Users.Actions;
using Fluxor;

namespace BlazorConduit.Services
{
    public class StateFacade
    {
        private readonly IDispatcher _dispatcher;

        public StateFacade(IDispatcher dispatcher) =>
            _dispatcher = dispatcher;

        /*
         * Authentication actions
         */
        public void RegisterUser(RegisterUserRequest request) =>
            _dispatcher.Dispatch(new RegisterUserAction(request));

    }
}
