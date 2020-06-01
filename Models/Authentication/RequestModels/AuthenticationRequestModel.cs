using BlazorConduit.Models.Authentication.Dtos;

namespace BlazorConduit.Models.Authentication.RequestModels
{
    public class AuthenticationRequestModel
    {
        public AuthenticationRequestModel(AuthenticationRequestDto user) =>
            User = user;

        public AuthenticationRequestDto User { get; }
    }
}
