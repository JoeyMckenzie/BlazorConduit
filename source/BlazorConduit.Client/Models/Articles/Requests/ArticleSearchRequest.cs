namespace BlazorConduit.Client.Models.Articles.Requests
{
    public class ArticleSearchRequest
    {
        public ArticleSearchRequest(
            int limit,
            int offset,
            string? author,
            string? favorited,
            string? tag)
        {
            Limit = limit;
            Offset = offset;
            Author = author;
            Favorited = favorited;
            Tag = tag;
        }

        public int Limit { get; }

        public int Offset { get; }

        public string? Author { get; }

        public string? Favorited { get; }

        public string? Tag { get; }
    }
}
