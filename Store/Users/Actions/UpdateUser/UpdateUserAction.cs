using BlazorConduit.Models.Authentication.Requests;

namespace BlazorConduit.Store.Users.Actions.UpdateUser
{
    public class UpdateUserAction
    {
        public UpdateUserAction(UpdateUserRequest requestModel) =>
            RequestModel = requestModel;

        public UpdateUserRequest RequestModel { get; }
    }
}
