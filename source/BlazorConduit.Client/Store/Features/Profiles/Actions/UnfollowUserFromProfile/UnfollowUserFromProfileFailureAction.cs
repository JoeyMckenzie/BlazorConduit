using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.UnfollowUserFromProfile
{
    public class UnfollowUserFromProfileFailureAction : FailureAction
    {
        public UnfollowUserFromProfileFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
