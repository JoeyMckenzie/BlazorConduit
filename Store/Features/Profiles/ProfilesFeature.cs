using BlazorConduit.Store.State;
using Fluxor;

namespace BlazorConduit.Store.Features.Profiles
{
    public class ProfilesFeature : Feature<ProfileState>
    {
        public override string GetName() => "Profiles";

        protected override ProfileState GetInitialState() => new ProfileState();
    }
}
