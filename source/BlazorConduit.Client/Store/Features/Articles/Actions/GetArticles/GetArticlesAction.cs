using BlazorConduit.Client.Models.Articles.Requests;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles
{
    public class GetArticlesAction
    {
        public GetArticlesAction(ArticleSearchRequest searchRequest, bool isFeed = false) =>
            (SearchRequest, IsFeed) = (searchRequest, isFeed);

        public ArticleSearchRequest SearchRequest { get; }

        public bool IsFeed { get; }
    }
}
