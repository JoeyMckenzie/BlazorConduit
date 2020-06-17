using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle
{
    public class RetrieveArticleSuccessAction
    {
        public RetrieveArticleSuccessAction(ArticleDto article, bool loadComments) =>
            (Article, LoadComments) = (article, loadComments);

        public ArticleDto Article { get; }

        public bool LoadComments { get; }
    }
}
