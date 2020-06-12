using BlazorConduit.Client.Models.Authentication.Dtos;

namespace BlazorConduit.Client.Models.Authentication.Requests
{
    public class UpdateUserRequest
    {
        public UpdateUserRequest(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
