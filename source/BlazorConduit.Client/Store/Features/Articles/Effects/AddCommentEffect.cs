using BlazorConduit.Client.Models.Articles.ViewModels;
using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Services;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Articles.Actions.AddComment;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects
{
    public class AddCommentEffect : Effect<AddCommentAction>
    {
        private readonly ILogger<AddCommentEffect> _logger;
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public AddCommentEffect(ILogger<AddCommentEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(AddCommentAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the article delete endpoint with the article slug
                var createResponse = await _apiService.PostAsync($"articles/{action.Slug}/comments", action.Comment, await _tokenService.GetTokenAsync());

                if (createResponse is null || !createResponse.IsSuccessStatusCode)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException($"Could not create article comment for article {action.Slug}", HttpStatusCode.InternalServerError);
                }

                var comment = await createResponse.Content.ReadFromJsonAsync<CommentViewModel>();

                if (comment is null || comment.Comment is null)
                {
                    throw new ConduitApiException("No comment was returned from successfull API response", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new AddCommentSuccessAction(comment.Comment));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError($"Validation error creating article comment for article {action.Slug}");
                dispatcher.Dispatch(new AddCommentFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error creating article comment for article {action.Slug}");
                dispatcher.Dispatch(new AddCommentFailureAction(e.Message));
            }
        }
    }
}
