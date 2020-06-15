using BlazorConduit.Client.Models.Articles.Requests;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle
{
    public class CreateArticleAction
    {
        public CreateArticleAction(CreateArticleRequest request) =>
            Request = request;

        public CreateArticleRequest Request { get; }
    }
}
