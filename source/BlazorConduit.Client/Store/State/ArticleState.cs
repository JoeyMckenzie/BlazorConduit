using System.Collections.Generic;
using System.Linq;
using BlazorConduit.Client.Models.Articles.Dtos;
using BlazorConduit.Client.Models.Articles.Requests;

namespace BlazorConduit.Client.Store.State
{
    public class ArticleState : RootState
    {
        public ArticleState(
            bool isLoading,
            IEnumerable<string>? errors,
            ArticleDto? currentArticle,
            bool? isFollowingUser,
            IEnumerable<ArticleDto>? currentArticleList,
            IEnumerable<CommentDto>? currentCommentList,
            ArticleSearchRequest? currentSearchRequest,
            int totalArticles)
            : base(isLoading, errors)
        {
            CurrentArticle = currentArticle;
            IsFollowingUser = isFollowingUser;
            CurrentArticleList = currentArticleList;
            CurrentCommentList = currentCommentList;
            CurrentSearchRequest = currentSearchRequest;
            TotalArticles = totalArticles;
        }

        public ArticleDto? CurrentArticle { get; }

        public bool? IsFollowingUser { get; }

        public IEnumerable<ArticleDto>? CurrentArticleList { get; }

        public IEnumerable<CommentDto>? CurrentCommentList { get; }

        public ArticleSearchRequest? CurrentSearchRequest { get; }

        public int TotalArticles { get; }

        public int TotalPages => TotalArticles > 0 ? TotalArticles / 10 : 1;
    }
}
