namespace BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUserFromProfile
{
    public class UnfollowUserFromProfileAction
    {
        public UnfollowUserFromProfileAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
