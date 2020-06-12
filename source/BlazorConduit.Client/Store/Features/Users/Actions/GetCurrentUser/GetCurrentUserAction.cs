namespace BlazorConduit.Client.Store.Features.Users.Actions.GetCurrentUser
{
    public class GetCurrentUserAction
    {
        public GetCurrentUserAction(string? token) =>
            Token = token;

        public string? Token { get; }
    }
}
