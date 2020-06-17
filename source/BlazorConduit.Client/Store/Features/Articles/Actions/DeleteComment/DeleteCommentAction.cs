namespace BlazorConduit.Client.Store.Features.Articles.Actions.DeleteComment
{
    public class DeleteCommentAction
    {
        public DeleteCommentAction(int id, string slug) =>
            (Id, Slug) = (id, slug);

        public int Id { get; }

        public string Slug { get; }
    }
}
