using System.Collections.Generic;

namespace BlazorConduit.Client.Store.State
{
    public class ArticleState : RootState
    {
        public ArticleState(bool isLoading, IEnumerable<string>? errors = null)
            : base(isLoading, errors)
        {
        }
    }
}
