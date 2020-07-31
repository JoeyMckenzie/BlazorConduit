using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.LoadComments;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.LoadComments
{
    public class LoadCommentsEffect : Effect<LoadCommentsAction>
    {
        private readonly ILogger<LoadCommentsEffect> _logger;
        private readonly ITokenService _tokenService;
        private readonly IConduitApiService _apiService;

        public LoadCommentsEffect(ILogger<LoadCommentsEffect> logger, ITokenService tokenService, IConduitApiService apiService) =>
            (_logger, _tokenService, _apiService) = (logger, tokenService, apiService);

        protected override async Task HandleAsync(LoadCommentsAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the login user endpoint with the constructed payload
                var commentsResponse = await _apiService.GetAsync<CommentViewModelList>($"articles/{action.Slug}/comments", await _tokenService.GetTokenAsync());

                if (commentsResponse is null || commentsResponse.Comments is null)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException("Could not retrieve article comments", HttpStatusCode.NotFound);
                }

                dispatcher.Dispatch(new LoadCommentsSuccessAction(commentsResponse.Comments));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError("API error during article comment retrieval");
                dispatcher.Dispatch(new LoadCommentsFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError("Error retrieving article comments");
                dispatcher.Dispatch(new LoadCommentsFailureAction(e.Message));
            }
        }
    }
}
