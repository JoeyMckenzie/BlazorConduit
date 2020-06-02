using BlazorConduit.Models.Authentication.RequestModels;

namespace BlazorConduit.Store.Users.Actions
{
    public class RegisterUserAction
    {
        public RegisterUserAction(RegisterUserRequest requestModel) =>
            RequestModel = requestModel;
        
        public RegisterUserRequest RequestModel { get; }
    }
}
