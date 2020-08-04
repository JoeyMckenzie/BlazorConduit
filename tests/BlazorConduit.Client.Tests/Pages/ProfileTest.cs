using BlazorConduit.Client.Pages;
<<<<<<< Updated upstream
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.State;
using BlazorConduit.Client.Tests.Mocks;
using Bunit;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Xunit;

namespace BlazorConduit.Client.Tests.Pages
{
    public class ProfileTest : TestContext
    {
        private readonly Mock<IStateFacade> _mockFacade;
        private readonly Mock<IState<UserState>> _mockUserState;
        private readonly Mock<IState<ArticleState>> _mockArticleState;
        private readonly Mock<IState<ProfileState>> _mockProfileState;
        private readonly Mock<NavigationManager> _mockNavigationManager;

        public ProfileTest()
        {
            _mockFacade = new Mock<IStateFacade>();
            _mockUserState = new Mock<IState<UserState>>();
            _mockArticleState = new Mock<IState<ArticleState>>();
            _mockProfileState = new Mock<IState<ProfileState>>();
            _mockNavigationManager = new Mock<NavigationManager>();
            Services.AddSingleton(_mockFacade.Object);
            Services.AddSingleton(_mockUserState.Object);
            Services.AddSingleton(_mockArticleState.Object);
            Services.AddSingleton(_mockProfileState.Object);
            Services.AddSingleton(_mockNavigationManager.Object);
            Services.AddMockNavigationManager();
        }

        [Fact(DisplayName = "Verify the markup is correctly rendered when page is loading")]
        public void GivenPageIsLoading_WhenProfileStateIsAvailable_DisplaysCorrectMarkup()
        {
            // Arrange
            const string expectedHtml = "<span>Loading profile...</span>";
            var isLoadingProfileState = new ProfileState(true, null, null);
            _mockProfileState.Setup(m => m.Value).Returns(isLoadingProfileState);

            // Act
            var component = RenderComponent<Profile>();

            // Assert
            component.MarkupMatches(expectedHtml);
        }

        [Fact(DisplayName = "Verify the markup is correctly rendered when page is loading")]
        public void GivenPageIsLoading_WhenNoUsernameIsPassedInPath_ReroutesToHome()
        {
            // Arrange
            var profileState = new ProfileState(true, null, null);
            _mockProfileState.Setup(m => m.Value).Returns(profileState);

            // Act
            var component = RenderComponent<Profile>();
            var navigationManager = Services.GetRequiredService<NavigationManager>() as MockNavigationManager;

            // Assert
            navigationManager.ShouldNotBeNull();
            navigationManager!.NavigateToLocation.ShouldBe("/");
            _mockFacade.Verify(m => m.GetUserProfile(It.IsAny<string>()), Times.Never);
            _mockFacade.Verify(m => m.GetArticles(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
    }
}
=======
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.State;
using BlazorConduit.Client.Tests.Mocks;
using Bunit;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Xunit;

namespace BlazorConduit.Client.Tests.Pages
{
    public class ProfileTest : TestContext
    {
        private readonly Mock<IStateFacade> _mockFacade;
        private readonly Mock<IState<UserState>> _mockUserState;
        private readonly Mock<IState<ArticleState>> _mockArticleState;
        private readonly Mock<IState<ProfileState>> _mockProfileState;
        private readonly Mock<NavigationManager> _mockNavigationManager;

        public ProfileTest()
        {
            _mockFacade = new Mock<IStateFacade>();
            _mockUserState = new Mock<IState<UserState>>();
            _mockArticleState = new Mock<IState<ArticleState>>();
            _mockProfileState = new Mock<IState<ProfileState>>();
            _mockNavigationManager = new Mock<NavigationManager>();
            Services.AddSingleton(_mockFacade.Object);
            Services.AddSingleton(_mockUserState.Object);
            Services.AddSingleton(_mockArticleState.Object);
            Services.AddSingleton(_mockProfileState.Object);
            Services.AddSingleton(_mockNavigationManager.Object);
            Services.AddMockNavigationManager();
        }

        [Fact(DisplayName = "Verify the markup is correctly rendered when page is loading")]
        public void GivenPageIsLoading_WhenProfileStateIsAvailable_DisplaysCorrectMarkup()
        {
            // Arrange
            var expectedHtml = "<span>Loading profile...</span>";
            var isLoadingProfileState = new ProfileState(true, null, null);
            _mockProfileState.Setup(m => m.Value).Returns(isLoadingProfileState);

            // Act
            var component = RenderComponent<Profile>();

            // Assert
            component.MarkupMatches(expectedHtml);
        }

        [Fact(DisplayName = "Verify that the state facade service is not invoked when no username is found in the path")]
        public void GivenPageIsLoading_WhenNoUsernameIsPassedInPath_ReroutesToHome()
        {
            // Arrange
            var profileState = new ProfileState(true, null, null);
            _mockProfileState.Setup(m => m.Value).Returns(profileState);

            // Act
            var component = RenderComponent<Profile>();
            var navigationManager = Services.GetRequiredService<NavigationManager>() as MockNavigationManager;

            // Assert
            navigationManager.ShouldNotBeNull();
            navigationManager!.NavigateToLocation.ShouldBe("/");
            _mockProfileState.VerifyAll();
            _mockFacade.Verify(m => m.GetUserProfile(It.IsAny<string>()), Times.Never);
            _mockFacade.Verify(m => m.GetArticles(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact(DisplayName = "Verify that the state facade service is invoked when a username is found in the path")]
        public void GivenPageIsLoading_WhenUsernameIsPassedInPath_DispatchesActionsFromFacade()
        {
            // Arrange
            var profileState = new ProfileState(true, null, null);
            _mockProfileState.Setup(m => m.Value).Returns(profileState);

            // Act
            var componentParameter = ComponentParameterFactory.Parameter(nameof(Profile.Username), "test");
            var component = RenderComponent<Profile>(componentParameter);

            // Assert
            _mockProfileState.VerifyAll();
            _mockFacade.Verify(m => m.GetUserProfile(It.IsAny<string>()), Times.Once);
            _mockFacade.Verify(m => m.GetArticles(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
>>>>>>> Stashed changes
