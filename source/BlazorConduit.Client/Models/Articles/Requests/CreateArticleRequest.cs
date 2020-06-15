using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Models.Articles.Requests
{
    public class CreateArticleRequest
    {
        public CreateArticleRequest(CreateArticleDto articleDto) =>
            Article = articleDto;

        public CreateArticleDto Article { get; }
    }
}
