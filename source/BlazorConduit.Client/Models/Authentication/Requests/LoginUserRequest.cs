using BlazorConduit.Client.Models.Authentication.Dtos;

namespace BlazorConduit.Client.Models.Authentication.Requests
{
    public class LoginUserRequest
    {
        public LoginUserRequest(LoginUserDto userDto) =>
            User = userDto;

        public LoginUserDto User { get; }
    }
}
