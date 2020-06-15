using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.UnfollowUserFromArticle
{
    public class UnfollowUserFromArticleFailureAction : FailureAction
    {
        public UnfollowUserFromArticleFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
