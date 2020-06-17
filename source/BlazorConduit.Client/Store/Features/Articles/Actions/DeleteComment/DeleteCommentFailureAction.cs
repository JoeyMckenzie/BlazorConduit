using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.DeleteComment
{
    public class DeleteCommentFailureAction : FailureAction
    {
        public DeleteCommentFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) 
            : base(reasonForFailure, errors)
        {
        }
    }
}
