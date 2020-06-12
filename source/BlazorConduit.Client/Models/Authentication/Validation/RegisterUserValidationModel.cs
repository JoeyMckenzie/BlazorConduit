using System.ComponentModel.DataAnnotations;

namespace BlazorConduit.Client.Models.Authentication.Validation
{
    public class RegisterUserValidationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
