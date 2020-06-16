using BlazorConduit.Client.Models.Articles.Dtos;
using BlazorConduit.Client.Models.Articles.Requests;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle
{
    public class UpdateArticleAction
    {
        public UpdateArticleAction(UpdateArticleDto updatedArticle) => 
            UpdatedArticle = updatedArticle;

        public UpdateArticleDto UpdatedArticle { get; }
    }
}
