using BlazorConduit.Client.Models.Common;
using BlazorConduit.Client.Models.Tags.Dtos;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.Features.Tags.Actions.GetTags;
using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects
{
    public class GetTagsEffect : Effect<GetTagsAction>
    {
        private readonly ILogger<GetTagsEffect> _logger;
        private readonly IConduitApiService _apiService;
        private readonly ITokenService _tokenService;

        public GetTagsEffect(ILogger<GetTagsEffect> logger, IConduitApiService apiService, ITokenService tokenService) =>
            (_logger, _apiService, _tokenService) = (logger, apiService, tokenService);

        protected override async Task HandleAsync(GetTagsAction action, IDispatcher dispatcher)
        {
            try
            {
                // Call the article delete endpoint with the article slug
                var tagResponse = await _apiService.GetAsync<TagListDto>("tags", await _tokenService.GetTokenAsync());

                if (tagResponse is null || tagResponse.Tags is null)
                {
                    // Throw the exception to issue the failure action
                    throw new ConduitApiException("Could retrieve tags", HttpStatusCode.InternalServerError);
                }

                dispatcher.Dispatch(new GetTagsSuccessAction(tagResponse.Tags));
            }
            catch (ConduitApiException e)
            {
                _logger.LogError("Validation retrieving tag list");
                dispatcher.Dispatch(new GetTagsFailureAction(e.Message, e.ApiErrors));
            }
            catch (Exception e)
            {
                _logger.LogError("Error retrieving tag list");
                dispatcher.Dispatch(new GetTagsFailureAction(e.Message));
            }
        }
    }
}
