using BlazorConduit.Models.Authentication.ViewModels;
using BlazorConduit.Models.Common;
using BlazorConduit.Services;
using BlazorConduit.Store.Users.Actions;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Users.Effects
{
    public class RegisterUserEffect : Effect<RegisterUserAction>
    {
        private readonly ConduitApiService _apiService;
        private readonly ErrorFormattingService _formattingService;
        private readonly ILogger<RegisterUserEffect> _logger;

        public RegisterUserEffect(ConduitApiService apiService, ErrorFormattingService formattingService, ILogger<RegisterUserEffect> logger) =>
            (_apiService, _formattingService, _logger) = (apiService, formattingService, logger);

        protected override async Task HandleAsync(RegisterUserAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the register user endpoint with the constructed payload
                var registerResponse = await _apiService.RegisterUser(action.RequestModel);

                if (!registerResponse.IsSuccessStatusCode)
                {
                    // Grab the error response from the API and convert them to singularly enumerable strings
                    var rawErrorResponse = await registerResponse.Content.ReadFromJsonAsync<object>();
                    var friendlyErrorResponses = _formattingService.GetFriendlyErrors(rawErrorResponse);

                    // Throw the exception to issue the failure action
                    throw new ConduitApiException(
                        $"Could not register user {action.RequestModel.User.Email}, status: {registerResponse.StatusCode}",
                        registerResponse.StatusCode,
                        friendlyErrorResponses);
                }

                // Registration was successful, issue the success action to set the current user state
                var user = await registerResponse.Content.ReadFromJsonAsync<ConduitUserViewModel>();

                if (user is null || user.User is null)
                {
                    throw new ConduitApiException("No user returned from successful API response", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new RegisterUserSuccessAction(user.User));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error during registration for user with email {action.RequestModel.User.Email}");
                dispatcher.Dispatch(new RegisterUserFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error register user with email {action.RequestModel.User.Email}");
                dispatcher.Dispatch(new RegisterUserFailureAction(e.Message));
            }
        }
    }
}
