using BlazorConduit.Models.Authentication.RequestModels;

namespace BlazorConduit.Store.Users.Actions
{
    public class RegisterUserAction
    {
        public RegisterUserAction(AuthenticationRequestModel requestModel) =>
            RequestModel = requestModel;

        public AuthenticationRequestModel RequestModel { get; }
    }
}
