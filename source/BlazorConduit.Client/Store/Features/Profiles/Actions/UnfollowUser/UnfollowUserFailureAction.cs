using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUser
{
    public class UnfollowUserFailureAction : FailureAction
    {
        public UnfollowUserFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
