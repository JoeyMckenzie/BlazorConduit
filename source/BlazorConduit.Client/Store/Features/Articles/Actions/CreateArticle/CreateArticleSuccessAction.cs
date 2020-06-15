using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle
{
    public class CreateArticleSuccessAction
    {
        public CreateArticleSuccessAction(ArticleDto article) =>
            Article = article;

        public ArticleDto Article { get; }
    }
}
