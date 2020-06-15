using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.FavoritePostFromArticle
{
    public class FavoritePostFromArticleSuccessAction
    {
        public FavoritePostFromArticleSuccessAction(ArticleDto article) => 
            Article = article;

        public ArticleDto Article { get; }
    }
}
