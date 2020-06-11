using System.Collections.Generic;

namespace BlazorConduit.Store.Users.Actions.LoadUserProfile
{
    public class LoadUserProfileFailureAction
    {
        public LoadUserProfileFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) =>
            (ReasonForFailure, Errors) = (reasonForFailure, errors);

        public string ReasonForFailure { get; }

        public IEnumerable<string>? Errors { get; }
    }
}
