using System.Collections.Generic;
using System.Text.Json;
using BlazorConduit.Client.Services.Contracts;

namespace BlazorConduit.Client.Services
{
    public class ErrorFormattingService : IErrorFormattingService
    {
        public IEnumerable<string> GetFriendlyErrors(object? apiErrors)
        {
            var friendlyApiErrors = new List<string>();

            if (apiErrors is null)
            {
                return friendlyApiErrors;
            }

            var coercedType = apiErrors.ToString();
            var deserialized = JsonDocument.Parse(System.Text.Encoding.UTF8.GetBytes(coercedType));

            /*
             * The following is disgusting and needs to be cleaned up appropriately.
             */

            // "error" will be the only element to enumerate
            foreach (var element in deserialized.RootElement.EnumerateObject())
            {
                // Traverse each node and reference the value
                foreach (var nestedElement in element.Value.EnumerateObject())
                {
                    // Each node will have a string array as the node value
                    // Add the node name and string value to the return array
                    foreach (var elementValue in nestedElement.Value.EnumerateArray())
                    {
                        friendlyApiErrors.Add($"{nestedElement.Name} {elementValue}");
                    }
                }
            }

            return friendlyApiErrors;
        }
    }
}
