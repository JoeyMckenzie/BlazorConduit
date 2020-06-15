using System.Collections.Generic;
using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.State
{
    public class ArticleState : RootState
    {
        public ArticleState(bool isLoading, IEnumerable<string>? errors, ArticleDto? currentArticle)
            : base(isLoading, errors)
        {
            CurrentArticle = currentArticle;
        }

        public ArticleDto? CurrentArticle { get; }
    }
}
