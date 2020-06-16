using BlazorConduit.Client.Models.Articles.Dtos;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.LoadComments
{
    public class LoadCommentsSuccessAction
    {
        public LoadCommentsSuccessAction(IEnumerable<CommentDto> comments) => 
            Comments = comments;

        public IEnumerable<CommentDto> Comments { get; }
    }
}
