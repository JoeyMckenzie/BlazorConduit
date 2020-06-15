using BlazorConduit.Client.Models.Articles.Dtos;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles
{
    public class GetArticlesSuccessAction
    {
        public GetArticlesSuccessAction(IEnumerable<ArticleDto> articles) =>
            Articles = articles;

        public IEnumerable<ArticleDto> Articles { get; }
    }
}
