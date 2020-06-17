namespace BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle
{
    public class RetrieveArticleAction
    {
        public RetrieveArticleAction(string slug, bool loadComments) =>
            (Slug, LoadComments) = (slug, loadComments);

        public string Slug { get; }

        public bool LoadComments { get; }
    }
}
