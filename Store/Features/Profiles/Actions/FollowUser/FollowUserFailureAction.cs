using BlazorConduit.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Store.Features.Profiles.Actions.FollowUser
{
    public class FollowUserFailureAction : FailureAction
    {
        public FollowUserFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
