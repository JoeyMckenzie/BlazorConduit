using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Services.Contracts;
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
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public GetArticlesEffect(ILogger<GetArticlesEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(GetArticlesAction action, IDispatcher dispatcher)
        {
            // Format the query string
            var queryString = new Dictionary<string, string>();

            // Add tag, if available
            if (!string.IsNullOrWhiteSpace(action.SearchRequest.Tag))
            {
                queryString.Add("tag", action.SearchRequest.Tag);
            }

            // Add author, if available
            if (!string.IsNullOrWhiteSpace(action.SearchRequest.Author))
            {
                queryString.Add("author", action.SearchRequest.Author);
            }

            // Add favorited, if available
            if (!string.IsNullOrWhiteSpace(action.SearchRequest.Favorited))
            {
                queryString.Add("favorited", action.SearchRequest.Favorited);
            }

            // Add limit and offset defaults
            var pageOffset = action.SearchRequest.Offset > 0 ? (action.SearchRequest.Offset - 1) * action.SearchRequest.Limit : action.SearchRequest.Offset;
            queryString.Add("limit", action.SearchRequest.Limit.ToString());
            queryString.Add("offset", pageOffset.ToString());

            try
            {
                // Build the aggregated query string
                var constructedQueryString = QueryHelpers.AddQueryString(action.IsFeed ? "articles/feed" : "articles", queryString);

                // Call the profile user endpoint with the username
                var articlesResponse = await _apiService.GetAsync<ArticleViewModelList>(constructedQueryString, await _tokenService.GetTokenAsync());

                if (articlesResponse is null || articlesResponse.Articles is null)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not retireve articles for query {constructedQueryString}", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new GetArticlesSuccessAction(articlesResponse.Articles, articlesResponse.ArticlesCount));
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
