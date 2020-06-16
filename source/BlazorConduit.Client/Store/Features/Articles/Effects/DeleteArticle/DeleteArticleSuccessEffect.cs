using BlazorConduit.Client.Store.Features.Articles.Actions.DeleteArticle;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles.Effects.DeleteArticle
{
    public class DeleteArticleSuccessEffect : Effect<DeleteArticleSuccessAction>
    {
        private readonly ILogger<DeleteArticleSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public DeleteArticleSuccessEffect(ILogger<DeleteArticleSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(DeleteArticleSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Article successfully deleted, navigating user to home");
            _navigation.NavigateTo("/");

            return Task.CompletedTask;
        }
    }
}
