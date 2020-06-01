using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Models.Authentication.Validation
{
    public class RegisterUserValidationModel
    {
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is request")]
        public string? Password { get; set; }
    }
}
