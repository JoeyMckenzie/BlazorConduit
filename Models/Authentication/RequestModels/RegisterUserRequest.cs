using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Models.Authentication.RequestModels
{
    public class RegisterUserRequest
    {
        public RegisterUserRequest(RegisterUserDto userDto) =>
            User = userDto;

        public RegisterUserDto User { get; }
    }
}
