namespace BlazorConduit.Client.Store.Features.Articles.Actions.FavoritePostFromArticle
{
    public class FavoritePostFromArticleAction
    {
        public FavoritePostFromArticleAction(string slug) =>
            Slug = slug;

        public string Slug { get; }
    }
}
