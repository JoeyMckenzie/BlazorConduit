describe('Home page', () => {
    beforeEach(() => cy.visit('/'));
    
    it('should retrieve and route the user to an article when clicked', () => {
        // Arrange, verify we're on the home page
        cy.contains('A place to share your knowledge.');

        // Act
        cy.get('.article-preview h1')
            .first()
            .then(articleTitle => {
                // Grab a reference to the article title
                const articleTitleInnerHtml = articleTitle.text();

                // Retrieve and navigate to the article page
                articleTitle.click();

                // Act, verify the title is correct
                cy.contains(articleTitleInnerHtml);
                cy.contains('Post Comment');
            });
    });

    it('should load articles based on tag', () => {
        // Arrange, verify we're on the home page
        cy.contains('A place to share your knowledge.');

        // Act, perform the search
        cy.get('.sidebar .tag-pill')
            .first()
            .click();

        // Assert    
        cy.get('.sidebar .tag-pill')
            .first()
            .then(tagPillElement => {
                // Grab a reference to first tag pill's inner text
                const tag = tagPillElement.text();

                // Act, verify the text is present on the tag feed
                cy.get('.ion-pound').parents().first().contains(tag);
            });
    });

    it('should not render the \'Your Feed\' element when the user is not logged in', () => {
        // Arrange, verify we're on the home page
        cy.contains('A place to share your knowledge.');

        // Act/Assert
        cy.contains('Your Feed').should('not.exist');
    });

    describe('when user has been authenticated', () => {
        // Login the test user before each spec run
        beforeEach(() => {
            // Arrange
            cy.contains('Sign In').click();
            const email = Cypress.env('email')
            const password = Cypress.env('password')

            // Act
            cy.get('#login-email-field').clear().type(email);
            cy.get('#login-password-field').clear().type(password);
            cy.get('[type=submit]').click();

            // Assert, wait for redirect to finish and verify the feed is there
            cy.wait(1500);
            cy.get('.logo-font');
            cy.contains('A place to share your knowledge.');
        });

        it('should load and highlight the user\'s feed when \'Your Feed\' is clicked', () => {
            // Arrange, verify we're on the home page
            cy.contains('A place to share your knowledge.');

            // Act, load the user feed
            cy.contains('Your Feed').click();
    
            // Assert
            cy.contains('Your Feed').should('have.class', 'active');
        });
    });
});
