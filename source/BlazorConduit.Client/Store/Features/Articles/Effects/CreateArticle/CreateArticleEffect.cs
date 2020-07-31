using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.CreateArticle
{
    public class CreateArticleEffect : Effect<CreateArticleAction>
    {
        private readonly ILogger<CreateArticleEffect> _logger;
        private readonly ITokenService _tokenService;
        private readonly IConduitApiService _apiService;
        private readonly IErrorFormattingService _formattingService;

        public CreateArticleEffect(
            ILogger<CreateArticleEffect> logger,
            ITokenService tokenService,
            IConduitApiService apiService,
            IErrorFormattingService formattingService)
        {
            _logger = logger;
            _tokenService = tokenService;
            _apiService = apiService;
            _formattingService = formattingService;
        }

        protected override async Task HandleAsync(CreateArticleAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the login user endpoint with the constructed payload
                var createResponse = await _apiService.PostAsync("articles", action.Request, await _tokenService.GetTokenAsync());

                if (!createResponse.IsSuccessStatusCode)
                {
                    // Grab the error response from the API and convert them to singularly enumerable strings
                    var rawErrorResponse = await createResponse.Content.ReadFromJsonAsync<object>();
                    var friendlyErrorResponses = _formattingService.GetFriendlyErrors(rawErrorResponse);

                    // Throw the exception to issue the failure action
                    throw new ConduitApiException(
                        $"Could not create article, status: {createResponse.StatusCode}",
                        createResponse.StatusCode,
                        friendlyErrorResponses);
                }

                // Registration was successful, issue the success action to set the current user state
                var article = await createResponse.Content.ReadFromJsonAsync<ArticleViewModel>();

                if (article is null || article.Article is null)
                {
                    throw new ConduitApiException("No article returned from successful API response", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new CreateArticleSuccessAction(article.Article));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error during article creation");
                dispatcher.Dispatch(new CreateArticleFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error creating article");
                dispatcher.Dispatch(new CreateArticleFailureAction(e.Message));
            }
        }
    }
}
