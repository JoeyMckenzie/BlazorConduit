using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Users
{
    public class UsersFeature : Feature<UserState>
    {
        public override string GetName() => "Users";

        protected override UserState GetInitialState() => UserState.FromInitialState();
    }
}
