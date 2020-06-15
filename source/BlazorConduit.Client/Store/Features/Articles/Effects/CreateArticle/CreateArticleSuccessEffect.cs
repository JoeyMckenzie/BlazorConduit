using System;
using System.Threading.Tasks;
using BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.CreateArticle
{
    public class CreateArticleSuccessEffect : Effect<CreateArticleSuccessAction>
    {
        private readonly ILogger<CreateArticleSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public CreateArticleSuccessEffect(ILogger<CreateArticleSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(CreateArticleSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation($"Article creation was successful, navigating to article {action.Article.Slug}");
            _navigation.NavigateTo($"article/{action.Article.Slug}");

            return Task.CompletedTask;
        }
    }
}
