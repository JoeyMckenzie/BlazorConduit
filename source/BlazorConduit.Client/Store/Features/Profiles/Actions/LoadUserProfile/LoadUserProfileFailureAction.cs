using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Profiles.Actions.LoadUserProfile
{
    public class LoadUserProfileFailureAction : FailureAction
    {
        public LoadUserProfileFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
