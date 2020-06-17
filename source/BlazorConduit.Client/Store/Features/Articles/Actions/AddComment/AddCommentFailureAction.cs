using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.AddComment
{
    public class AddCommentFailureAction : FailureAction
    {
        public AddCommentFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
