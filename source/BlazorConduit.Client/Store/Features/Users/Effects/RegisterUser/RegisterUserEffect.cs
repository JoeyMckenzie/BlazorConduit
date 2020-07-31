using BlazorConduit.Client.Models.Authentication.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Users.Actions.RegisterUser;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Users.Effects.RegisterUser
{
    public class RegisterUserEffect : Effect<RegisterUserAction>
    {
        private readonly IConduitApiService _apiService;
        private readonly IErrorFormattingService _formattingService;
        private readonly ILogger<RegisterUserEffect> _logger;

        public RegisterUserEffect(IConduitApiService apiService, IErrorFormattingService formattingService, ILogger<RegisterUserEffect> logger) =>
            (_apiService, _formattingService, _logger) = (apiService, formattingService, logger);

        protected override async Task HandleAsync(RegisterUserAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the register user endpoint with the constructed payload
                var registerResponse = await _apiService.PostAsync("users", action.RequestModel);

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
