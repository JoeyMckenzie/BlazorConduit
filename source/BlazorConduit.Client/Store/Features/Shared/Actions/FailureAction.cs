using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Shared.Actions
{
    public abstract class FailureAction
    {
        protected FailureAction(string reasonForFailure, IEnumerable<string>? errors = null) =>
            (ReasonForFailure, Errors) = (reasonForFailure, errors);

        public string ReasonForFailure { get; }

        public IEnumerable<string>? Errors { get; }
    }
}
