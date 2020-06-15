namespace BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle
{
    public class RetrieveArticleAction
    {
        public RetrieveArticleAction(string slug) =>
            Slug = slug;

        public string Slug { get; }
    }
}
