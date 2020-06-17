using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Tags
{
    public class TagsFeature : Feature<TagState>
    {
        public override string GetName() => "Tags";

        protected override TagState GetInitialState() =>
            new TagState(false, null, null);
    }
}
