using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.UpdateArticle
{
    public class UpdateArticleEffect : Effect<UpdateArticleAction>
    {
        private readonly ILogger<UpdateArticleEffect> _logger;
        private readonly ITokenService _tokenService;
        private readonly IConduitApiService _apiService;
        private readonly IErrorFormattingService _formattingService;

        public UpdateArticleEffect(
            ILogger<UpdateArticleEffect> logger,
            ITokenService tokenService,
            IConduitApiService apiService,
            IErrorFormattingService formattingService)
        {
            _logger = logger;
            _tokenService = tokenService;
            _apiService = apiService;
            _formattingService = formattingService;
        }

        protected override async Task HandleAsync(UpdateArticleAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the login user endpoint with the constructed payload
                var updateResponse = await _apiService.PutAsync($"articles/{action.UpdatedArticle.Slug}", action.UpdatedArticle, await _tokenService.GetTokenAsync());

                if (!updateResponse.IsSuccessStatusCode)
                {
                    // Grab the error response from the API and convert them to singularly enumerable strings
                    var rawErrorResponse = await updateResponse.Content.ReadFromJsonAsync<object>();
                    var friendlyErrorResponses = _formattingService.GetFriendlyErrors(rawErrorResponse);

                    // Throw the exception to issue the failure action
                    throw new ConduitApiException(
                        $"Could not update article, status: {updateResponse.StatusCode}",
                        updateResponse.StatusCode,
                        friendlyErrorResponses);
                }

                // Registration was successful, issue the success action to set the current user state
                var article = await updateResponse.Content.ReadFromJsonAsync<ArticleViewModel>();

                if (article is null || article.Article is null)
                {
                    throw new ConduitApiException("No article returned from successful API response", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new UpdateArticleSuccessAction(article.Article));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error during article creation");
                dispatcher.Dispatch(new UpdateArticleFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error creating article");
                dispatcher.Dispatch(new UpdateArticleFailureAction(e.Message));
            }
        }
    }
}
