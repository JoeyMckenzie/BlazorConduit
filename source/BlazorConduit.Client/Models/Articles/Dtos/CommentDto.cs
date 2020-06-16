using BlazorConduit.Client.Models.Profiles;
using System;

namespace BlazorConduit.Client.Models.Articles.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? Body { get; set; }

        public UserProfileDto? Author { get; set; }
    }
}
