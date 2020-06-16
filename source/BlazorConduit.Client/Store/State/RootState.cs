using System.Collections.Generic;
using System.Linq;

namespace BlazorConduit.Client.Store.State
{
    public abstract class RootState
    {
        protected RootState(bool isLoading = false, IEnumerable<string>? errors = null) =>
            (IsLoading, CurrentErrors) = (isLoading, errors);

        public bool IsLoading { get; }

        public IEnumerable<string>? CurrentErrors { get; }

        public bool HasCurrentErrors => !(CurrentErrors is null) && CurrentErrors.Any();
    }
}
