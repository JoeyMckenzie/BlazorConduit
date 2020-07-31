using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.DeleteArticle;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.DeleteArticle
{
    public class DeleteArticleEffect : Effect<DeleteArticleAction>
    {
        private readonly ILogger<DeleteArticleEffect> _logger;
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public DeleteArticleEffect(ILogger<DeleteArticleEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(DeleteArticleAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the article delete endpoint with the article slug
                var deleteResponse = await _apiService.DeleteNoContentAsync($"articles/{action.Slug}", await _tokenService.GetTokenAsync());

                if (deleteResponse is null || !deleteResponse.IsSuccessStatusCode)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not delete article {action.Slug}", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new DeleteArticleSuccessAction());
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error deleting of article {action.Slug}");
                dispatcher.Dispatch(new DeleteArticleFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error deleting of article {action.Slug}");
                dispatcher.Dispatch(new DeleteArticleFailureAction(e.Message));
            }
        }
    }
}
