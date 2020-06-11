using Fluxor;

namespace BlazorConduit.Store
{
    public class AppFeature : Feature<AppState>
    {
        public override string GetName() => "App";

        protected override AppState GetInitialState() => new AppState(false, null, null, null);
    }
}
