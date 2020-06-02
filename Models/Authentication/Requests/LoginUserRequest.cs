using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Models.Authentication.Requests
{
    public class LoginUserRequest
    {
        public LoginUserRequest(LoginUserDto userDto) =>
            User = userDto;

        public LoginUserDto User { get; }
    }
}
