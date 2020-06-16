using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.UpdateArticle
{
    public class UpdateArticleFailureAction : FailureAction
    {
        public UpdateArticleFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) 
            : base(reasonForFailure, errors)
        {
        }
    }
}
