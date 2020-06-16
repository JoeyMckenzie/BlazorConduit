namespace BlazorConduit.Client.Models.Articles.Dtos
{
    public class UpdateArticleDto
    {
        public UpdateArticleDto(string? title, string? description, string? body, string slug) =>
            (Title, Description, Body, Slug) = (title, description, body, slug);

        public string? Title { get; }

        public string? Description { get; }

        public string? Body { get; }

        public string Slug { get; }
    }
}
