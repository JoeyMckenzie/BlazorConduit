using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle
{
    public class RetrieveArticleSuccessAction
    {
        public RetrieveArticleSuccessAction(ArticleDto article) =>
            Article = article;

        public ArticleDto Article { get; }
    }
}
