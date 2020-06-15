using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.GetArticles
{
    public class GetArticlesFailureAction : FailureAction
    {
        public GetArticlesFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) 
            : base(reasonForFailure, errors)
        {
        }
    }
}
