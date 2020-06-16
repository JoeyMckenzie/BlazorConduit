using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Models.Articles.Requests
{
    public class UpdateArticleRequest
    {
        public UpdateArticleRequest(UpdateArticleDto request) => 
            Request = request;

        public UpdateArticleDto Request { get; }
    }
}
