using BlazorConduit.Client.Models.Authentication.Requests;

namespace BlazorConduit.Client.Store.Features.Users.Actions.UpdateUser
{
    public class UpdateUserAction
    {
        public UpdateUserAction(UpdateUserRequest requestModel) =>
            RequestModel = requestModel;

        public UpdateUserRequest RequestModel { get; }
    }
}
