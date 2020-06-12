namespace BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile
{
    public class LoadUserProfileAction
    {
        public LoadUserProfileAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
