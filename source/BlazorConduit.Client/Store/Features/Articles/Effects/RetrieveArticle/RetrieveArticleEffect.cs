using System;
using System.Net;
using System.Threading.Tasks;
using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.RetrieveArticle
{
    public class RetrieveArticleEffect : Effect<RetrieveArticleAction>
    {
        private readonly ILogger<RetrieveArticleEffect> _logger;
        private readonly SecurityTokenService _tokenService;
        private readonly ConduitApiService _apiService;

        public RetrieveArticleEffect(ILogger<RetrieveArticleEffect> logger, SecurityTokenService tokenService, ConduitApiService apiService) =>
            (_logger, _tokenService, _apiService) = (logger, tokenService, apiService);

        protected override async Task HandleAsync(RetrieveArticleAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the login user endpoint with the constructed payload
                var retrieveResponse = await _apiService.GetAsync<ArticleViewModel>($"articles/{action.Slug}", await _tokenService.GetTokenAsync());

                if (retrieveResponse is null || retrieveResponse.Article is null)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException("Could not retrieve article", HttpStatusCode.NotFound);
                }

                dispatcher.Dispatch(new RetrieveArticleSuccessAction(retrieveResponse.Article));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError("API error during article retrieval");
                dispatcher.Dispatch(new RetrieveArticleFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError("Error retrieving article");
                dispatcher.Dispatch(new RetrieveArticleFailureAction(e.Message));
            }
        }
    }
}
