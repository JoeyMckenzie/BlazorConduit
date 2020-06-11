using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Store.Features.Users.Actions.LoginUser
{
    public class LoginUserSuccessAction
    {
        public LoginUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
