using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles;
using Fluxor;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects
{
    public class GetArticlesEffect : Effect<GetArticlesAction>
    {
        private readonly ILogger<GetArticlesEffect> _logger;
        private readonly ConduitApiService _apiService;
        private readonly SecurityTokenService _tokenService;

        public GetArticlesEffect(ILogger<GetArticlesEffect> logger, ConduitApiService apiService, SecurityTokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(GetArticlesAction action, IDispatcher dispatcher)
        {
            // Format the query string
            var queryString = new Dictionary<string, string>();

            // Add tag, if available
            if (!string.IsNullOrWhiteSpace(action.Tag))
            {
                queryString.Add(nameof(action.Tag), action.Tag);
            }

            // Add author, if available
            if (!string.IsNullOrWhiteSpace(action.Author))
            {
                queryString.Add(nameof(action.Author), action.Author);
            }

            // Add favorited, if available
            if (!string.IsNullOrWhiteSpace(action.Favorited))
            {
                queryString.Add(nameof(action.Favorited), action.Favorited);
            }

            // Add limit, if available
            if (action.Limit.HasValue)
            {
                queryString.Add(nameof(action.Limit), action.Limit.Value.ToString());
            }

            // Add offset, if available
            if (action.Offset.HasValue)
            {
                queryString.Add(nameof(action.Offset), action.Offset.Value.ToString());
            }

            try
            {
                // Build the aggregated query string
                var constructedQueryString = QueryHelpers.AddQueryString("articles", queryString);

                // Call the profile user endpoint with the username
                var articlesResponse = await _apiService.GetAsync<ArticleViewModelList>(constructedQueryString, await _tokenService.GetTokenAsync());

                if (articlesResponse is null || articlesResponse.Articles is null)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not retireve articles for query {constructedQueryString}", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new GetArticlesSuccessAction(articlesResponse.Articles));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError("Validation error during article search");
                dispatcher.Dispatch(new GetArticlesFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError("Error during profile article search");
                dispatcher.Dispatch(new GetArticlesFailureAction(e.Message));
            }
        }
    }
}
