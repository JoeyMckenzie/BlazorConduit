using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.LoadComments
{
    public class LoadCommentsFailureAction : FailureAction
    {
        public LoadCommentsFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) 
            : base(reasonForFailure, errors)
        {
        }
    }
}
