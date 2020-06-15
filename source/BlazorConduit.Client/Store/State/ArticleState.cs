using System.Collections.Generic;
using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.State
{
    public class ArticleState : RootState
    {
        public ArticleState(bool isLoading, IEnumerable<string>? errors, ArticleDto? currentArticle, bool? isFollowingUser, IEnumerable<ArticleDto>? currentArticleList)
            : base(isLoading, errors)
        {
            CurrentArticle = currentArticle;
            IsFollowingUser = isFollowingUser;
            CurrentArticleList = currentArticleList;
        }

        public ArticleDto? CurrentArticle { get; }

        public bool? IsFollowingUser { get; }

        public IEnumerable<ArticleDto>? CurrentArticleList { get; }
    }
}
