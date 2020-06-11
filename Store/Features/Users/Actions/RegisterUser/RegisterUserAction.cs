using BlazorConduit.Models.Authentication.Requests;

namespace BlazorConduit.Store.Features.Users.Actions.RegisterUser
{
    public class RegisterUserAction
    {
        public RegisterUserAction(RegisterUserRequest requestModel) =>
            RequestModel = requestModel;

        public RegisterUserRequest RequestModel { get; }
    }
}
