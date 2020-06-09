using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Models.Authentication.Requests
{
    public class UpdateUserRequest
    {
        public UpdateUserRequest(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
