using BlazorConduit.Models.Common.ViewModels;
using System.Collections.Generic;

namespace BlazorConduit.Store.Users.Actions
{
    public class RegisterUserFailureAction
    {
        public RegisterUserFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) =>
            (ReasonForFailure, Errors) = (reasonForFailure, errors);

        public string ReasonForFailure { get; }

        public IEnumerable<string>? Errors { get; }
    }
}
