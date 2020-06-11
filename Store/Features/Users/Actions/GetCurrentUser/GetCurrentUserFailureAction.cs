using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Features.Users.Actions.GetCurrentUser
{
    public class GetCurrentUserFailureAction
    {
        public GetCurrentUserFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) =>
            (ReasonForFailure, Errors) = (reasonForFailure, errors);

        public string ReasonForFailure { get; }

        public IEnumerable<string>? Errors { get; }
    }
}
