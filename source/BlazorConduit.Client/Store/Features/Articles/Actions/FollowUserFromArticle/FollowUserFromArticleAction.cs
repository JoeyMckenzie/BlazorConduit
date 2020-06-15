namespace BlazorConduit.Client.Store.Features.Articles.Actions.FollowUserFromArticle
{
    public class FollowUserFromArticleAction
    {
        public FollowUserFromArticleAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
