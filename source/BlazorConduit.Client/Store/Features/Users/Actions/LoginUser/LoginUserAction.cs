using BlazorConduit.Client.Models.Authentication.Requests;

namespace BlazorConduit.Client.Store.Features.Users.Actions.LoginUser
{
    public class LoginUserAction
    {
        public LoginUserAction(LoginUserRequest requestModel) =>
            RequestModel = requestModel;

        public LoginUserRequest RequestModel { get; }
    }
}
