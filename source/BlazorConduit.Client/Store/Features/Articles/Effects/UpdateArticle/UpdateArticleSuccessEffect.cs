using BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.UpdateArticle
{
    public class UpdateArticleSuccessEffect :Effect<UpdateArticleSuccessAction>
    {
        private readonly ILogger<UpdateArticleSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public UpdateArticleSuccessEffect(ILogger<UpdateArticleSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(UpdateArticleSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation($"Article update was successful, navigating to article {action.Article.Slug}");
            _navigation.NavigateTo($"article/{action.Article.Slug}");

            return Task.CompletedTask;
        }
    }
}
