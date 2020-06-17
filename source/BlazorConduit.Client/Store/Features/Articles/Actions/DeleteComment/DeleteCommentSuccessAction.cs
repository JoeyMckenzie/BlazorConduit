namespace BlazorConduit.Client.Store.Features.Articles.Actions.DeleteComment
{
    public class DeleteCommentSuccessAction
    {
        public DeleteCommentSuccessAction(int id) =>
            Id = id;

        public int Id { get; }
    }
}
