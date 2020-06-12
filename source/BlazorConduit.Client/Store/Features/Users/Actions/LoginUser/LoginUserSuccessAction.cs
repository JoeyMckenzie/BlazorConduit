using BlazorConduit.Client.Models.Authentication.Dtos;

namespace BlazorConduit.Client.Store.Features.Users.Actions.LoginUser
{
    public class LoginUserSuccessAction
    {
        public LoginUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
