namespace BlazorConduit.Store.Users.Actions.LoadUserProfile
{
    public class LoadUserProfileAction
    {
        public LoadUserProfileAction(string username) =>
            Username = username;

        public string Username { get; }
    }
}
