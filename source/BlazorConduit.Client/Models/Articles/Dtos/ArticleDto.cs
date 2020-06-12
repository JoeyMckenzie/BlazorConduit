using BlazorConduit.Client.Models.Profiles;
using System;
using System.Collections.Generic;

namespace BlazorConduit.Client.Models.Articles.Dtos
{
    public class ArticleDto
    {
        public string? Slug { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Body { get; set; }

        public IEnumerable<string>? TagList { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Favorited { get; set; }

        public int FavoritesCount { get; set; }

        public UserProfileDto? Author { get; set; }
    }
}
