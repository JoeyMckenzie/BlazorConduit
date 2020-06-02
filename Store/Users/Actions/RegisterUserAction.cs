using BlazorConduit.Models.Authentication.Requests;

namespace BlazorConduit.Store.Users.Actions
{
    public class RegisterUserAction
    {
        public RegisterUserAction(LoginUserRequest requestModel) =>
            RequestModel = requestModel;
        
        public LoginUserRequest RequestModel { get; }
    }
}
