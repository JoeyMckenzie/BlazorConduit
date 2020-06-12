using BlazorConduit.Client.Models.Authentication.Dtos;

namespace BlazorConduit.Client.Store.Features.Users.Actions.RegisterUser
{
    public class RegisterUserSuccessAction
    {
        public RegisterUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
