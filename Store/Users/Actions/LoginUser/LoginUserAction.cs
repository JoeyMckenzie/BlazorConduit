using BlazorConduit.Models.Authentication.Requests;

namespace BlazorConduit.Store.Users.Actions.LoginUser
{
    public class LoginUserAction
    {
        public LoginUserAction(LoginUserRequest requestModel) =>
            RequestModel = requestModel;

        public LoginUserRequest RequestModel { get; }
    }
}
