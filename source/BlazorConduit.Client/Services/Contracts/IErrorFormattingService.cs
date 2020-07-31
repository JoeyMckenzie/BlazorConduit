using System.Collections.Generic;

namespace BlazorConduit.Client.Services.Contracts
{
    public interface IErrorFormattingService
    {
        IEnumerable<string> GetFriendlyErrors(object? apiErrors);
    }
}
