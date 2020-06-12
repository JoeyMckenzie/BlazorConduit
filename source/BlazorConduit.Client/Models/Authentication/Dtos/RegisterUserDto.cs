namespace BlazorConduit.Client.Models.Authentication.Dtos
{
    public class RegisterUserDto
    {
        public RegisterUserDto(string username, string email, string password) =>
            (Username, Email, Password) = (username, email, password);

        public string Username { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
