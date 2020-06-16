namespace BlazorConduit.Client.Store.Features.Articles.Actions.LoadComments
{
    public class LoadCommentsAction
    {
        public LoadCommentsAction(string slug) => 
            Slug = slug;

        public string Slug { get; }
    }
}
