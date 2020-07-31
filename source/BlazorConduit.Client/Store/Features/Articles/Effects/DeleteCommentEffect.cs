using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.DeleteComment;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects
{
    public class DeleteCommentEffect : Effect<DeleteCommentAction>
    {
        private readonly ILogger<DeleteCommentEffect> _logger;
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public DeleteCommentEffect(ILogger<DeleteCommentEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(DeleteCommentAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the article delete endpoint with the article slug
                var deleteResponse = await _apiService.DeleteNoContentAsync($"articles/{action.Slug}/comments/{action.Id}", await _tokenService.GetTokenAsync());

                if (deleteResponse is null || !deleteResponse.IsSuccessStatusCode)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not delete article comment {action.Id} for article {action.Slug}", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new DeleteCommentSuccessAction(action.Id));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error deleting article comment {action.Id} for article {action.Slug}");
                dispatcher.Dispatch(new DeleteCommentFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error deleting article comment {action.Id} for article {action.Slug}");
                dispatcher.Dispatch(new DeleteCommentFailureAction(e.Message));
            }
        }
    }
}
