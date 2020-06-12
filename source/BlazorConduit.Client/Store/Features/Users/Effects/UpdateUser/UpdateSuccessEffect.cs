using BlazorConduit.Client.Store.Features.Users.Actions.RegisterUser;
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Users.Effects.UpdateUser
{
    public class UpdateUserSuccessEffect : Effect<RegisterUserSuccessAction>
    {
        private readonly ILocalStorageService _storageService;
        private readonly ILogger<UpdateUserSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public UpdateUserSuccessEffect(
            ILocalStorageService storageService,
            ILogger<UpdateUserSuccessEffect> logger,
            NavigationManager navigation)
        {
            _storageService = storageService;
            _logger = logger;
            _navigation = navigation;
        }

        protected override async Task HandleAsync(RegisterUserSuccessAction action, IDispatcher dispatcher)
        {
            // Cache the access token in local storage, overrides if already existing
            _logger.LogInformation($"Caching access token on successful user update for user {action.User.Email}");
            await _storageService.SetItemAsync("token", action.User.Token);

            // Navigate back to the home page
            _navigation.NavigateTo("/");
        }
    }
}
