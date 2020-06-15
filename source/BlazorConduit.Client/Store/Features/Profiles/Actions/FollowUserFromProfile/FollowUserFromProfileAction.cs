namespace BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUserFromProfile
{
    public class FollowUserFromProfileAction
    {
        public FollowUserFromProfileAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
