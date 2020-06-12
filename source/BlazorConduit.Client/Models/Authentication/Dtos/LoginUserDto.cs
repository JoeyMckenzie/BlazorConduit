namespace BlazorConduit.Client.Models.Authentication.Dtos
{
    public class LoginUserDto
    {
        public LoginUserDto(string email, string password) =>
            (Email, Password) = (email, password);

        public string Email { get; }

        public string Password { get; }
    }
}
