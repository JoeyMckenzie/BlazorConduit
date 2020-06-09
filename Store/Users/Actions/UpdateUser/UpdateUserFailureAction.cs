using System.Collections.Generic;

namespace BlazorConduit.Store.Users.Actions.UpdateUser
{
    public class UpdateUserFailureAction
    {
        public UpdateUserFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) =>
            (ReasonForFailure, Errors) = (reasonForFailure, errors);

        public string ReasonForFailure { get; }

        public IEnumerable<string>? Errors { get; }
    }
}
