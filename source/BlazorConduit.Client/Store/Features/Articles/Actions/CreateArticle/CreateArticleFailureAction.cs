using System.Collections.Generic;
using BlazorConduit.Client.Store.Features.Shared.Actions;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.CreateArticle
{
    public class CreateArticleFailureAction : FailureAction
    {
        public CreateArticleFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
