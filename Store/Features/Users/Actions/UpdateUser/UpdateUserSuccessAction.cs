using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Store.Features.Users.Actions.UpdateUser
{
    public class UpdateUserSuccessAction
    {
        public UpdateUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
