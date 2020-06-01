using BlazorConduit.Models.Authentication.ViewModels;
using BlazorConduit.Services;
using BlazorConduit.Store.Users.Actions;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Users.Effects
{
    public class RegisterUserEffect : Effect<RegisterUserAction>
    {
        private readonly ConduitApiService _apiService;
        private readonly ILogger<RegisterUserEffect> _logger;

        public RegisterUserEffect(ConduitApiService apiService, ILogger<RegisterUserEffect> logger) =>
            (_apiService, _logger) = (apiService, logger);

        protected override async Task HandleAsync(RegisterUserAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the register user endpoint with the constructed payload
                var registerResponse = await _apiService.RegisterUser(action.RequestModel);

                if (!registerResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Could not register user {action.RequestModel.User.Email}, status: {registerResponse.StatusCode}");
                }

                var user = await registerResponse.Content.ReadFromJsonAsync<ConduitUserViewModel>();
                dispatcher.Dispatch(new RegisterUserSuccessAction(user));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error register user with email {action.RequestModel.User.Email}");
                dispatcher.Dispatch(new RegisterUserFailureAction(e.Message));
            }
        }
    }
}
