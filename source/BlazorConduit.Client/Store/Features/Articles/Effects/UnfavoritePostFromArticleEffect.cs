using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.UnfavoritePostFromArticle;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects
{
    public class UnfavoritePostFromArticleEffect : Effect<UnfavoritePostFromArticleAction>
    {
        private readonly ILogger<UnfavoritePostFromArticleEffect> _logger;
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public UnfavoritePostFromArticleEffect(ILogger<UnfavoritePostFromArticleEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(UnfavoritePostFromArticleAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the favorite article endpoint with the slug
                var unfavoriteResponse = await _apiService.DeleteNoContentAsync($"articles/{action.Slug}/favorite", await _tokenService.GetTokenAsync());

                if (unfavoriteResponse is null || !unfavoriteResponse.IsSuccessStatusCode)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not unfavorite article {action.Slug}", HttpStatusCode.InternalServerError);
                }

                var article = await unfavoriteResponse.Content.ReadFromJsonAsync<ArticleViewModel>();

                if (article is null || article.Article is null)
                {
                    throw new ConduitApiException($"Article {action.Slug} was not returned by API", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new UnfavoritePostFromArticleSuccessAction(article.Article));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error during article unfavorite for slug {action.Slug}");
                dispatcher.Dispatch(new UnfavoritePostFromArticleFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during article unfavorite for slug {action.Slug}");
                dispatcher.Dispatch(new UnfavoritePostFromArticleFailureAction(e.Message));
            }
        }
    }
}
