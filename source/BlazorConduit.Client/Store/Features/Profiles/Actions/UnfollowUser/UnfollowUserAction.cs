namespace BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUser
{
    public class UnfollowUserAction
    {
        public UnfollowUserAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
