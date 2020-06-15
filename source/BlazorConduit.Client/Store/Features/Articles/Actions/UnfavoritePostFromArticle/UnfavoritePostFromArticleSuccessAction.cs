using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.UnfavoritePostFromArticle
{
    public class UnfavoritePostFromArticleSuccessAction
    {
        public UnfavoritePostFromArticleSuccessAction(ArticleDto article) =>
            Article = article;

        public ArticleDto Article { get; }
    }
}
