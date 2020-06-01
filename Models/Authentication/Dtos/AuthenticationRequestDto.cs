using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Models.Authentication.Dtos
{
    public class AuthenticationRequestDto
    {
        public AuthenticationRequestDto(string? userName, string email, string password) =>
            (UserName, Email, Password) = (userName, email, password);

        public string? UserName { get; }

        public string Email { get; }

        public string Password { get; set; }
    }
}
