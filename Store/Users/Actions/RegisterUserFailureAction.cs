namespace BlazorConduit.Store.Users.Actions
{
    public class RegisterUserFailureAction
    {
        public RegisterUserFailureAction(string reasonForFailure) =>
            ReasonForFailure = reasonForFailure;

        public string ReasonForFailure { get; }
    }
}
