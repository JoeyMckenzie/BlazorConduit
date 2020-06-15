using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.FollowUserFromProfile
{
    public class FollowUserFromProfileFailureAction : FailureAction
    {
        public FollowUserFromProfileFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
