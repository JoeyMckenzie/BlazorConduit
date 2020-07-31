using BlazorConduit.Client.Models.Authentication.Requests;
using BlazorConduit.Client.Pages;
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
    public class RegisterTest : TestContext
    {
        private readonly Mock<IStateFacade> _mockFacade;
        private readonly Mock<IState<UserState>> _mockUserState;

        public RegisterTest()
        {
            _mockFacade = new Mock<IStateFacade>();
            _mockUserState = new Mock<IState<UserState>>();
            Services.AddSingleton(_mockFacade.Object);
            Services.AddSingleton(_mockUserState.Object);

            // Setup the unauthenticated state
            var unauthenticatedState = new UserState(false, null, null);
            _mockUserState.Setup(m => m.Value).Returns(unauthenticatedState);
        }

        [Fact(DisplayName = "Verify the initial markup is correct")]
        public void GivenInitialPageLoad_WhenComponentHasRendered_DisplaysCorrectMarkup()
        {
            // Arrange
            const string expectedHtml = @"
<div class='auth-page'>
    <div class='container page'>
        <div class='row'>
            <div class='col-md-6 offset-md-3 col-xs-12'>
                <h1 class='text-xs-center'>Sign up</h1>

                <p class='text-xs-center'>
                    <a href='/login'>Have an account?</a>
                </p>

                <form>
                    <ul class='error-messages'>
                    </ul>

                    <fieldset>
                        <fieldset class='form-group'>
                            <input id='register-username-field' placeholder='Your Name' type='text' class='form-control form-control-lg valid'>
                        </fieldset>
                        <fieldset class='form-group'>
                            <input id='register-email-field' placeholder='Email' type='email' class='form-control form-control-lg valid'>
                        </fieldset>
                        <fieldset class='form-group'>
                            <input id='register-password-field' placeholder='Password' type='password' class='form-control form-control-lg valid'>
                        </fieldset>

                        <button class='btn btn-lg pull-xs-right btn-primary' type='submit'>
                            Sign up
                        </button>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>
</div>";

            // Act
            var component = RenderComponent<Register>();

            // Assert
            component.MarkupMatches(expectedHtml);
        }

        [Fact(DisplayName = "Verify the error messages are displayed when submit is clicked with invalid form values")]
        public void GivenInvalidForm_WhenSubmitIsClicked_DisplaysErrorMessages()
        {
            // Arrange, render the component
            var component = RenderComponent<Register>();

            // Act, click the sign in button
            component.Find("form").Submit();

            // Assert, verify messages are rendered
            component.Find(".error-messages").ChildElementCount.ShouldBe(3);
            component.FindAll("li").ShouldContain(e => string.Equals(e.InnerHtml, "Username is required"));
            component.FindAll("li").ShouldContain(e => string.Equals(e.InnerHtml, "Email is required"));
            component.FindAll("li").ShouldContain(e => string.Equals(e.InnerHtml, "Password is required"));
        }

        [Fact(DisplayName = "Verify the error messages are removed when values are entered")]
        public void GivenInvalidForm_WhenInputHasBeenEntered_RemovesDisplayedErrorMessages()
        {
            // Arrange, render the component
            var component = RenderComponent<Register>();

            // Act, click the sign in button
            component.Find("form").Submit();

            // Assert, verify messages are rendered
            component.Find(".error-messages").ChildElementCount.ShouldBe(3);
            component.FindAll("li").ShouldContain(e => string.Equals(e.InnerHtml, "Username is required"));
            component.FindAll("li").ShouldContain(e => string.Equals(e.InnerHtml, "Email is required"));
            component.FindAll("li").ShouldContain(e => string.Equals(e.InnerHtml, "Password is required"));

            // Enter input and verify messages are removed
            component.Find("#register-username-field").Change("test");
            component.Find("#register-email-field").Change("test");
            component.Find("#register-password-field").Change("test");
            component.Find(".error-messages").ChildElementCount.ShouldBe(0);
        }

        [Fact(DisplayName = "Verify register user action is dispatched when a valid form is submitted")]
        public void GivenValidForm_WhenSubmitIsClicked_DispatchesLoginActionUsingFacade()
        {
            // Arrange, render the component
            var component = RenderComponent<Register>();

            // Act, click the sign in button
            component.Find("#register-username-field").Change("test");
            component.Find("#register-email-field").Change("test@gmail.com");
            component.Find("#register-password-field").Change("test");
            component.Find("form").Submit();

            // Assert
            component.Find(".error-messages").ChildElementCount.ShouldBe(0);
            _mockFacade.Verify(m => m.RegisterUser(It.IsAny<RegisterUserRequest>()), Times.Once);
        }
    }
}
