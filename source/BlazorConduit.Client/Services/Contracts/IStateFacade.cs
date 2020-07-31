using BlazorConduit.Client.Models.Articles.Dtos;
using BlazorConduit.Client.Models.Articles.Requests;
using BlazorConduit.Client.Models.Authentication.Requests;

namespace BlazorConduit.Client.Services.Contracts
{
    public interface IStateFacade
    {
        public void RegisterUser(RegisterUserRequest request);

        public void LoginUser(LoginUserRequest request);

        public void UpdateUser(UpdateUserRequest request);

        public void GetCurrentUser(string? token = null);

        /**
         * Profile actions
         */
        public void GetUserProfile(string username);

        public void FollowUserProfile(string username);

        public void UnfollowUserProfile(string username);

        /**
         * Article actions
         */
        public void CreateArticle(CreateArticleRequest request);

        public void RetrieveArticle(string slug, bool loadComments = true);

        public void UpdateArticle(UpdateArticleDto article);

        public void DeleteArticle(string slug);

        public void AddComment(CreateCommentRequest comment, string slug);

        public void DeleteComment(int id, string slug);

        public void GetArticles(
            string? tag = null,
            string? author = null,
            string? favorited = null,
            int? limit = null,
            int? offset = null);

        public void GetFeed(
            string? tag = null,
            string? author = null,
            string? favorited = null,
            int? limit = null,
            int? offset = null);

        public void FollowUserFromArticle(string username);

        public void UnfollowUserFromArticle(string username);

        public void FavoritePostFromArticle(string slug);

        public void UnfavoritePostFromArticle(string slug);

        /**
         * Tag actions
         */
        public void LoadTags();
    }
}
