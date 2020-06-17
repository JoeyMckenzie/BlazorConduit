using System.Collections.Generic;
using BlazorConduit.Client.Models.Articles.Dtos;
using BlazorConduit.Client.Models.Articles.ViewModels;

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
            IEnumerable<CommentDto>? currentCommentList)
            : base(isLoading, errors)
        {
            CurrentArticle = currentArticle;
            IsFollowingUser = isFollowingUser;
            CurrentArticleList = currentArticleList;
            CurrentCommentList = currentCommentList;
        }

        public ArticleDto? CurrentArticle { get; }

        public bool? IsFollowingUser { get; }

        public IEnumerable<ArticleDto>? CurrentArticleList { get; }

        public IEnumerable<CommentDto>? CurrentCommentList { get; }
    }
}
