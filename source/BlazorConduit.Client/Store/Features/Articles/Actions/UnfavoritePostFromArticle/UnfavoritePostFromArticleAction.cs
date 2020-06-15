namespace BlazorConduit.Client.Store.Features.Articles.Actions.UnfavoritePostFromArticle
{
    public class UnfavoritePostFromArticleAction
    {
        public UnfavoritePostFromArticleAction(string slug) =>
            Slug = slug;

        public string Slug { get; }
    }
}
