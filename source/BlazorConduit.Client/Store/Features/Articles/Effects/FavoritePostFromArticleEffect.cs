using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.FavoritePostFromArticle;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects
{
    public class FavoritePostFromArticleEffect : Effect<FavoritePostFromArticleAction>
    {
        private readonly ILogger<FavoritePostFromArticleEffect> _logger;
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public FavoritePostFromArticleEffect(ILogger<FavoritePostFromArticleEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(FavoritePostFromArticleAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the favorite article endpoint with the slug
                var favoriteResponse = await _apiService.PostNoContentAsync($"articles/{action.Slug}/favorite", await _tokenService.GetTokenAsync());

                if (favoriteResponse is null || !favoriteResponse.IsSuccessStatusCode)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not favorite article {action.Slug}", HttpStatusCode.InternalServerError);
                }

                var article = await favoriteResponse.Content.ReadFromJsonAsync<ArticleViewModel>();

                if (article is null || article.Article is null)
                {
                    throw new ConduitApiException($"Article {action.Slug} was not returned by API", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new FavoritePostFromArticleSuccessAction(article.Article));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error during article favorite for slug {action.Slug}");
                dispatcher.Dispatch(new FavoritePostFromArticleFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during article favorite for slug {action.Slug}");
                dispatcher.Dispatch(new FavoritePostFromArticleFailureAction(e.Message));
            }
        }
    }
}
