using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Users.Actions.RegisterUser
{
    public class RegisterUserFailureAction : FailureAction
    {
        public RegisterUserFailureAction(string reasonForFailure, IEnumerable<string>? errors = null)
            : base(reasonForFailure, errors)
        {
        }
    }
}
