namespace BlazorConduit.Client.Store.Features.Articles.Actions.UnfollowUserFromArticle
{
    public class UnfollowUserFromArticleAction
    {
        public UnfollowUserFromArticleAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
