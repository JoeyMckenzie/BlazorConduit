using Microsoft.AspNetCore.Components;

namespace BlazorConduit.Client.Tests.Mocks
{
    /// <summary>
    /// Mock for Blazor's NavigationManager that is bootstrapped from application startup.
    /// Implementation used is the current solution from the bUnit community, see <see cref="https://github.com/egil/bUnit/issues/73#issuecomment-597828532"/>.
    /// </summary>
    public class MockNavigationManager : NavigationManager
    {
        public MockNavigationManager()
        {
            EnsureInitialized();
        }

        public string? NavigateToLocation { get; private set; }

        /// <summary>
        /// Navigates to the specified URI.
        /// </summary>
        /// <param name="uri">The destination URI. This can be absolute, or relative to the base URI
        /// (as returned by <see cref="NavigationManager.BaseUri"/>).</param>
        /// <param name="forceLoad">If true, bypasses client-side routing and forces the browser to load the new page from the server, whether or not the URI would normally be handled by the client-side router.</param>
        public new virtual void NavigateTo(string uri, bool forceLoad = false)
        {
            NavigateToCore(uri, forceLoad);
        }

        protected override void NavigateToCore(string uri, bool forceLoad)
        {
            NavigateToLocation = uri;
            Uri = $"{BaseUri}{uri}";
        }

        protected sealed override void EnsureInitialized()
        {
            Initialize("http://localhost:5000/", "http://localhost:5000/");
        }
    }
}
