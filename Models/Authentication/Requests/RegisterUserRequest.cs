using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Models.Authentication.Requests
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest(RegisterUserDto userDto) =>
            User = userDto;

        public RegisterUserDto User { get; }
    }
}
