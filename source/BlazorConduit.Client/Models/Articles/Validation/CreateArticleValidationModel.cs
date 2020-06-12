using System.ComponentModel.DataAnnotations;

namespace BlazorConduit.Client.Models.Articles.Validation
{
    public class CreateArticleValidationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is a required field")]
        public string? Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Body is a required field")]
        public string? Body { get; set; }
    }
}
