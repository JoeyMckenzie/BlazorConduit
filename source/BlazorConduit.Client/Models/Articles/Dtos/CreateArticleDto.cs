using System.Collections.Generic;

namespace BlazorConduit.Client.Models.Articles.Dtos
{
    public class CreateArticleDto
    {
        public CreateArticleDto(
            string title,
            string description,
            string body,
            IEnumerable<string>? tagList = null)
        {
            Title = title;
            Description = description;
            Body = body;
            TagList = tagList;
        }

        public string Title { get; }

        public string Description { get; }

        public string Body { get; }

        public IEnumerable<string>? TagList { get; }
    }
}
