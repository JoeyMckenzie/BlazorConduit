namespace BlazorConduit.Client.Models.Articles.Dtos
{
    public class CreateCommentDto
    {
        public CreateCommentDto(string body) => 
            Body = body;

        public string Body { get; }
    }
}
