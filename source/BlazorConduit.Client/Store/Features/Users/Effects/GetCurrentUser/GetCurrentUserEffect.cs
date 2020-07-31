using BlazorConduit.Client.Models.Authentication.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Users.Actions.GetCurrentUser;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Users.Effects.GetCurrentUser
{
    public class GetCurrentUserEffect : Effect<GetCurrentUserAction>
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<GetCurrentUserEffect> _logger;
        private readonly IConduitApiService _apiService;

        public GetCurrentUserEffect(
            ITokenService tokenService,
            ILogger<GetCurrentUserEffect> logger,
            IConduitApiService apiService)
        {
            _tokenService = tokenService;
            _logger = logger;
            _apiService = apiService;
        }

        protected override async Task HandleAsync(GetCurrentUserAction action, IDispatcher dispatcher)
        {
            try
            {
                var currentToken = string.IsNullOrWhiteSpace(action.Token) ? await _tokenService.GetTokenAsync() : action.Token;

                // Call the current user endpoint with the currently cached token
                var currentUserResponse = await _apiService.GetAsync<ConduitUserViewModel>("user", currentToken);

                if (currentUserResponse is null || currentUserResponse.User is null)
                {
                    throw new ConduitApiException("No user returned from successful API response", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new GetCurrentUserSuccessAction(currentUserResponse.User));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError("No user on response returned from API");
                dispatcher.Dispatch(new GetCurrentUserFailureAction(e.Message));
            }
            catch (Exception e)
            {
                _logger.LogError($"An error has occurred retrieving the current user, reason: {e.Message}");
                dispatcher.Dispatch(new GetCurrentUserFailureAction(e.Message));
            }
        }
    }
}
