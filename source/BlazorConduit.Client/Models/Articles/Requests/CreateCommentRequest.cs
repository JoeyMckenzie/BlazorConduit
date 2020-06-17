using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Models.Articles.Requests
{
    public class CreateCommentRequest
    {
        public CreateCommentRequest(CreateCommentDto comment) => 
            Comment = comment;

        public CreateCommentDto Comment { get; }
    }
}
