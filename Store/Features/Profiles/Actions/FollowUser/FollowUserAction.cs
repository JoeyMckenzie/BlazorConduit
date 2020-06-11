namespace BlazorConduit.Store.Profiles.Actions.FollowUser
{
    public class FollowUserAction
    {
        public FollowUserAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
