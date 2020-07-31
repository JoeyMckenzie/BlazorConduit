using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.FollowUserFromArticle;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.FollowUserFromArticle
{
    public class FollowUserFromArticleEffect : Effect<FollowUserFromArticleAction>
    {
        private readonly ILogger<FollowUserFromArticleEffect> _logger;
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public FollowUserFromArticleEffect(ILogger<FollowUserFromArticleEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(FollowUserFromArticleAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the profile user endpoint with the username
                var followResponse = await _apiService.PostNoContentAsync($"profiles/{action.Username}/follow", await _tokenService.GetTokenAsync());

                if (followResponse is null || !followResponse.IsSuccessStatusCode)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not follow user profile {action.Username}", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new FollowUserFromArticleSuccessAction());
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error during profile follow for user {action.Username}");
                dispatcher.Dispatch(new FollowUserFromArticleFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during profile follow for user {action.Username}");
                dispatcher.Dispatch(new FollowUserFromArticleFailureAction(e.Message));
            }
        }
    }
}
