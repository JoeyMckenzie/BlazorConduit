using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Profiles
{
    public class ProfilesFeature : Feature<ProfileState>
    {
        public override string GetName() => "Profiles";

        protected override ProfileState GetInitialState() => 
            new ProfileState(false, null, null);
    }
}
