using BlazorConduit.Store.State;
using Fluxor;

namespace BlazorConduit.Store.Features.Users
{
    public class UsersFeature : Feature<UserState>
    {
        public override string GetName() => "Users";

        protected override UserState GetInitialState() => UserState.FromInitialState();
    }
}
