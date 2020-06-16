using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle
{
    public class UpdateArticleSuccessAction
    {
        public UpdateArticleSuccessAction(ArticleDto article) => 
            Article = article;

        public ArticleDto Article { get; }
    }
}
