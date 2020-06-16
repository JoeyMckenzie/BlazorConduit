using System.ComponentModel.DataAnnotations;

namespace BlazorConduit.Client.Models.Articles.Validation
{
    public class UpdateArticleValidationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Updated title cannot be empty")]
        public string? Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Updated description cannot be empty")]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Updated body cannot be empty")]
        public string? Body { get; set; }
    }
}
