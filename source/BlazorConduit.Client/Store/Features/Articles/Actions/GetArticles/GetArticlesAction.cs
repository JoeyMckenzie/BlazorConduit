namespace BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles
{
    public class GetArticlesAction
    {
        public GetArticlesAction(
            string? tag,
            string? author,
            string? favorited,
            int? limit,
            int? offset)
        {
            Tag = tag;
            Author = author;
            Favorited = favorited;
            Limit = limit;
            Offset = offset;
        }

        public string? Tag { get; set; }

        public string? Author { get; set; }

        public string? Favorited { get; set; }

        public int? Limit { get; set; }

        public int? Offset { get; set; }
    }
}
