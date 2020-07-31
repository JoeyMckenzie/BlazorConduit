using System.Collections.Generic;

namespace BlazorConduit.Client.Store.State
{
    public class TagState : RootState
    {
        public TagState(bool isLoading, IEnumerable<string>? errors, IEnumerable<string>? tags)
            : base(isLoading, errors) => Tags = tags;

        public IEnumerable<string>? Tags { get; }
    }
}
