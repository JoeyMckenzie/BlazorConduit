using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Models.Authentication.Dtos
{
    public class ConduitUserDto
    {
        public string? Email { get; set; }

        public string? Token { get; set; }

        public string? Username { get; set; }

        public string? Bio { get; set; }

        public string? Image { get; set; }
    }
}
