using BlazorConduit.Client.Models.Authentication.Dtos;

namespace BlazorConduit.Client.Store.Features.Users.Actions.UpdateUser
{
    public class UpdateUserSuccessAction
    {
        public UpdateUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
