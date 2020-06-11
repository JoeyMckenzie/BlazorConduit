using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Store.Features.Users.Actions.RegisterUser
{
    public class RegisterUserSuccessAction
    {
        public RegisterUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
