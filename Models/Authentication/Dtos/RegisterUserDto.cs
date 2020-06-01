namespace BlazorConduit.Models.Authentication.Dtos
{
    public class RegisterUserDto
    {
        public RegisterUserDto(string userName, string email, string password) =>
            (UserName, Email, Password) = (UserName, email, password);

        public string UserName { get; set; }

        public string Email { get; }

        public string Password { get; }
    }
}
