using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.UnfavoritePostFromArticle
{
    public class UnfavoritePostFromArticleFailureAction : FailureAction
    {
        public UnfavoritePostFromArticleFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
