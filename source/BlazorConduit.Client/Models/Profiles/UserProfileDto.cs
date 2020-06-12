using System;

namespace BlazorConduit.Client.Models.Profiles
{
    public class UserProfileDto
    {
        public string? Username { get; set; }

        public string? Bio { get; set; }

        public string? Image { get; set; }

        public bool Following { get; set; }
    }
}
