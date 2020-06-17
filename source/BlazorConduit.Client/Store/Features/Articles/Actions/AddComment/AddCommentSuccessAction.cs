using BlazorConduit.Client.Models.Articles.Dtos;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.AddComment
{
    public class AddCommentSuccessAction
    {
        public AddCommentSuccessAction(CommentDto comment) =>
            Comment = comment;

        public CommentDto Comment { get; }
    }
}
