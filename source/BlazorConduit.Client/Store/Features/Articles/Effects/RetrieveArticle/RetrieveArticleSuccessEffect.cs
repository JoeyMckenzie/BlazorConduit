using System.Threading.Tasks;
using BlazorConduit.Client.Store.Features.Articles.Actions.LoadComments;
using BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.RetrieveArticle
{
    public class RetrieveArticleSuccessEffect : Effect<RetrieveArticleSuccessAction>
    {
        private readonly ILogger<RetrieveArticleSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public RetrieveArticleSuccessEffect(ILogger<RetrieveArticleSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(RetrieveArticleSuccessAction action, IDispatcher dispatcher)
        {
            if (action.LoadComments && !string.IsNullOrWhiteSpace(action.Article.Slug))
            {
                _logger.LogInformation($"Loading comments for article {action.Article.Slug}");
                dispatcher.Dispatch(new LoadCommentsAction(action.Article.Slug));
            }

            _logger.LogInformation($"Article retrieval was successful, navigating to article {action.Article.Slug}");
            _navigation.NavigateTo($"article/{action.Article.Slug}");

            return Task.CompletedTask;
        }
    }
}
