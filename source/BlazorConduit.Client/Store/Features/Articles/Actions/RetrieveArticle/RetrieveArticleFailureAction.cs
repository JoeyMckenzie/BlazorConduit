using System.Collections.Generic;
using BlazorConduit.Client.Store.Features.Shared.Actions;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.RetrieveArticle
{
    public class RetrieveArticleFailureAction : FailureAction
    {
        public RetrieveArticleFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) 
            : base(reasonForFailure, errors)
        {
        }
    }
}
