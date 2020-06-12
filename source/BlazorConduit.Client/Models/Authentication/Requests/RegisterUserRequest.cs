using BlazorConduit.Client.Models.Authentication.Dtos;

namespace BlazorConduit.Client.Models.Authentication.Requests
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest(RegisterUserDto userDto) =>
            User = userDto;

        public RegisterUserDto User { get; }
    }
}
