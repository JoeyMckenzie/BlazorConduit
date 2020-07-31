using BlazorConduit.Client.Models.Authentication.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Users.Actions.LoginUser;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Users.Effects.LoginUser
{
    public class LoginUserEffect : Effect<LoginUserAction>
    {
        private readonly IConduitApiService _apiService;
        private readonly IErrorFormattingService _formattingService;
        private readonly ILogger<LoginUserEffect> _logger;

        public LoginUserEffect(IConduitApiService apiService, IErrorFormattingService formattingService, ILogger<LoginUserEffect> logger) =>
            (_apiService, _formattingService, _logger) = (apiService, formattingService, logger);

        protected override async Task HandleAsync(LoginUserAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the login user endpoint with the constructed payload
                var loginResponse = await _apiService.PostAsync("users/login", action.RequestModel);

                if (!loginResponse.IsSuccessStatusCode)
                {
                    // Grab the error response from the API and convert them to singularly enumerable strings
                    var rawErrorResponse = await loginResponse.Content.ReadFromJsonAsync<object>();
                    var friendlyErrorResponses = _formattingService.GetFriendlyErrors(rawErrorResponse);

                    // Throw the exception to issue the failure action
                    throw new ConduitApiException(
                        $"Could not login user {action.RequestModel.User.Email}, status: {loginResponse.StatusCode}",
                        loginResponse.StatusCode,
                        friendlyErrorResponses);
                }

                // Registration was successful, issue the success action to set the current user state
                var user = await loginResponse.Content.ReadFromJsonAsync<ConduitUserViewModel>();

                if (user is null || user.User is null)
                {
                    throw new ConduitApiException("No user returned from successful API response", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new LoginUserSuccessAction(user.User));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error during registration for user with email {action.RequestModel.User.Email}");
                dispatcher.Dispatch(new LoginUserFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error register user with email {action.RequestModel.User.Email}");
                dispatcher.Dispatch(new LoginUserFailureAction(e.Message));
            }
        }
    }
}
