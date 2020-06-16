namespace BlazorConduit.Client.Store.Features.Articles.Actions.DeleteArticle
{
    public class DeleteArticleAction
    {
        public DeleteArticleAction(string slug) => 
            Slug = slug;

        public string Slug { get; }
    }
}
