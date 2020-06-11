using BlazorConduit.Store.State;
using Fluxor;

namespace BlazorConduit.Store.Features.Users
{
    public class UsersFeature : Feature<AppState>
    {
        public override string GetName() => "Users";

        protected override AppState GetInitialState() => AppState.FromInitialState();
    }
}
