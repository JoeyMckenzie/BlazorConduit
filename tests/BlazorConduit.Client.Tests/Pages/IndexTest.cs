using System.Linq;
using BlazorConduit.Client.Models.Articles.Requests;
using BlazorConduit.Client.Models.Authentication.Dtos;
using BlazorConduit.Client.Services.Contracts;
using BlazorConduit.Client.Store.State;
using Bunit;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Xunit;

namespace BlazorConduit.Client.Tests.Pages
{
    public class IndexTest : TestContext
    {
        private readonly Mock<IStateFacade> _mockFacade;
        private readonly Mock<IState<UserState>> _mockUserState;
        private readonly Mock<IState<ArticleState>> _mockArticleState;
        private readonly Mock<IState<TagState>> _mockTagState;

        public IndexTest()
        {
            _mockFacade = new Mock<IStateFacade>();
            _mockUserState = new Mock<IState<UserState>>();
            _mockTagState = new Mock<IState<TagState>>();
            _mockArticleState = new Mock<IState<ArticleState>>();
            Services.AddSingleton(_mockFacade.Object);
            Services.AddSingleton(_mockUserState.Object);
            Services.AddSingleton(_mockTagState.Object);
            Services.AddSingleton(_mockArticleState.Object);
        }

        [Fact(DisplayName = "Verify the global feed is displayed when no user is found")]
        public void GivenInitialLoad_WhenUserIsNotAuthenticated_DisplaysGlobalFeed()
        {
            // Arrange, setup our mock states
            var unauthenticatedState = new UserState(false, null, null);
            var tagState = new TagState(false, null, null);
            var articleState = new ArticleState(false, null, null, null, null, null, null, 0);
            _mockUserState.Setup(s => s.Value).Returns(unauthenticatedState);
            _mockTagState.Setup(s => s.Value).Returns(tagState);
            _mockArticleState.Setup(s => s.Value).Returns(articleState);

            // Act
            var component = RenderComponent<Client.Pages.Index>();

            // Assert, verify only the global feed is rendered
            component.FindAll(".nav-item").Count.ShouldBe(1);
            component.Find(".nav-item").FirstElementChild.InnerHtml.ShouldBe("Global Feed");
        }

        [Fact(DisplayName = "Verify the global and user feeds are displayed and highlighted when global feed is defaulted")]
        public void GivenInitialLoad_WhenUserAuthenticated_DisplaysFeedsAndHighlightsGlobal()
        {
            // Arrange, setup our mock states
            var authenticatedState = new UserState(false, null, new ConduitUserDto { Username = "test" });
            var tagState = new TagState(false, null, null);
            var articleState = new ArticleState(false, null, null, null, null, null, null, 0);
            _mockUserState.Setup(s => s.Value).Returns(authenticatedState);
            _mockTagState.Setup(s => s.Value).Returns(tagState);
            _mockArticleState.Setup(s => s.Value).Returns(articleState);

            // Act
            var component = RenderComponent<Client.Pages.Index>();

            // Assert
            component.FindAll(".nav-item").Count.ShouldBe(2);
            component.FindAll(".nav-item").First().FirstElementChild.InnerHtml.ShouldBe("Your Feed");
            component.FindAll(".nav-item").Last().FirstElementChild.InnerHtml.ShouldBe("Global Feed");
            component.FindAll(".nav-item").Last().LastElementChild.ClassList.ShouldContain("active");
        }

        [Fact(DisplayName = "Verify user feed is highlighted when clicked")]
        public void GivenComponentIsLoaded_WhenUserClicksFeed_HighlightsUserFeed()
        {
            // Arrange, setup our mock states
            var authenticatedState = new UserState(false, null, new ConduitUserDto { Username = "test" });
            var tagState = new TagState(false, null, null);
            var articleState = new ArticleState(false, null, null, null, null, null, null, 0);
            _mockUserState.Setup(s => s.Value).Returns(authenticatedState);
            _mockTagState.Setup(s => s.Value).Returns(tagState);
            _mockArticleState.Setup(s => s.Value).Returns(articleState);

            // Act, render the component and invoke the @onclick handler for the user feed
            var component = RenderComponent<Client.Pages.Index>();
            component.FindAll(".nav-link").First().ClassList.ShouldNotContain("active");
            component.FindAll(".nav-link").First().Click();

            // Assert, verify Your Feed is active
            component.FindAll(".nav-link").First().InnerHtml.ShouldBe("Your Feed");
            component.FindAll(".nav-link").First().ClassList.ShouldContain("active");
        }

        [Fact(DisplayName = "Verify tag feed is highlighted when the search request state contains a tag")]
        public void GivenTagExistsInSearchRequest_WhenFeedIsRendered_HighlightsTagFeed()
        {
            // Arrange, setup our mock states
            var authenticatedState = new UserState(false, null, new ConduitUserDto { Username = "test" });
            var tagState = new TagState(false, null, null);
            var articleState = new ArticleState(false, null, null, null, null, null, new ArticleSearchRequest(0, 0, null, null, "test"), 0);
            _mockUserState.Setup(s => s.Value).Returns(authenticatedState);
            _mockTagState.Setup(s => s.Value).Returns(tagState);
            _mockArticleState.Setup(s => s.Value).Returns(articleState);

            // Act
            var component = RenderComponent<Client.Pages.Index>();
            var tagListItem = component.FindAll(".nav-item").Last();

            // Assert, verify the tag feed is active
            component.FindAll(".nav-item").Count.ShouldBe(3);

            // Assert the anchor tag is active
            tagListItem.FirstElementChild.ClassList.ShouldContain("active");

            // Assert the iconic pound sign is rendered
            tagListItem.FirstElementChild.FirstElementChild.ClassList.ShouldContain("ion-pound");

            // Assert the text is displayed in the anchor title
            tagListItem.FirstElementChild.LastElementChild.InnerHtml.ShouldContain(articleState.CurrentSearchRequest!.Tag);
        }

        [Fact(DisplayName = "Verify the get articles and load tags actions are dispatched on page initialization")]
        public void GivenInitialPageLoad_WhenLifecycleIsInvoked_DispatchesActionsFromFacade()
        {
            // Arrange, setup our mock states
            var authenticatedState = new UserState(false, null, new ConduitUserDto { Username = "test" });
            var tagState = new TagState(false, null, null);
            var articleState = new ArticleState(false, null, null, null, null, null, new ArticleSearchRequest(0, 0, null, null, "test"), 0);
            _mockUserState.Setup(s => s.Value).Returns(authenticatedState);
            _mockTagState.Setup(s => s.Value).Returns(tagState);
            _mockArticleState.Setup(s => s.Value).Returns(articleState);
 
            // Act
            var component = RenderComponent<Client.Pages.Index>();

            // Assert
            _mockFacade.Verify(m => m.GetArticles(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), 10, 0), Times.Once);
            _mockFacade.Verify(m => m.LoadTags(), Times.Once);
        }

        [Fact(DisplayName = "Verify the tag list is displayed when a list exists in tag state")]
        public void GivenPopulatedTagsInState_WhenPageIsRendered_DisplaysTagList()
        {
            // Arrange, setup our mock states
            var authenticatedState = new UserState(false, null, new ConduitUserDto { Username = "test" });
            var tagState = new TagState(false, null, new[] { "test" });
            var articleState = new ArticleState(false, null, null, null, null, null, null, 0);
            _mockUserState.Setup(s => s.Value).Returns(authenticatedState);
            _mockTagState.Setup(s => s.Value).Returns(tagState);
            _mockArticleState.Setup(s => s.Value).Returns(articleState);
 
            // Act
            var component = RenderComponent<Client.Pages.Index>();

            // Assert
            component.Find(".sidebar").ShouldNotBeNull();
            component.Find(".sidebar").ChildElementCount.ShouldBe(2);
            component.Find(".tag-list").ChildElementCount.ShouldBe(1);
            component.Find(".tag-pill.tag-default").InnerHtml.ShouldBe(tagState.Tags.First());
        }

        [Fact(DisplayName = "Verify that get articles action is dispatch when tag is clicked from the tag list")]
        public void GivenPopulatedTagsInState_WhenIsClicked_DispatchesGetArticlesActionFromFacade()
        {
            // Arrange, setup our mock states
            var authenticatedState = new UserState(false, null, new ConduitUserDto { Username = "test" });
            var tagState = new TagState(false, null, new[] { "test" });
            var articleState = new ArticleState(false, null, null, null, null, null, null, 0);
            _mockUserState.Setup(s => s.Value).Returns(authenticatedState);
            _mockTagState.Setup(s => s.Value).Returns(tagState);
            _mockArticleState.Setup(s => s.Value).Returns(articleState);
 
            // Act
            var component = RenderComponent<Client.Pages.Index>();
            component.Find(".tag-pill.tag-default").Click();

            // Assert, will be call on page initialization and on tag click
            _mockFacade.Verify(m => m.GetArticles(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), 10, 0), Times.Exactly(2));
            _mockFacade.Verify(m => m.GetArticles(tagState.Tags.First(), It.IsAny<string>(), It.IsAny<string>(), 10, 0), Times.Once);
        }
    }
}
