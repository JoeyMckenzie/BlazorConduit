using BlazorConduit.Client.Models.Articles.Requests;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.AddComment
{
    public class AddCommentAction
    {
        public AddCommentAction(CreateCommentRequest comment, string slug) =>
            (Comment, Slug) = (comment, slug);

        public CreateCommentRequest Comment { get; }

        public string Slug { get; }
    }
}
