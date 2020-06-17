using System.Collections;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Tags.Actions.GetTags
{
    public class GetTagsSuccessAction
    {
        public GetTagsSuccessAction(IEnumerable<string> tags) => 
            Tags = tags;

        public IEnumerable<string> Tags { get; }
    }
}
