using System;

namespace BlazorConduit.Models.Profile
{
    public class UserProfileDto
    {
        public string? Username { get; set; }

        public string? Bio { get; set; }

        public string? Image { get; set; }

        public bool Following { get; set; }

        public bool ValueEquals(UserProfileDto userProfile)
        {
            // Compare usernames, capture letter case differing
            if (!string.Equals(Username, userProfile.Username, StringComparison.CurrentCulture))
            {
                return false;
            }

            // Compare bios, capture letter case differing
            if (!string.Equals(Bio, userProfile.Bio, StringComparison.CurrentCulture))
            {
                return false;
            }

            // Compare images, capture letter case differing
            if (!string.Equals(Image, userProfile.Image, StringComparison.CurrentCulture))
            {
                return false;
            }

            return true;
        }
    }
}
