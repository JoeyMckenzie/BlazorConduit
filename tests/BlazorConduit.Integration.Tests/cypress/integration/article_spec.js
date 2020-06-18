describe('Creating, editing, and deleting an article', () => {
    // Login the test user before each spec run
    it('should login and navigate to the editor page', () => {
        // Arrange
        cy.visit('/');
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

        // Navigate to the editor
        cy.contains('New Article').click();
    });
    
    it('should display validation messages for title, description, and body on invalid form submit', () => {
        // Act
        cy.get('[type=submit]').click();

        // Assert
        cy.get('.error-messages');
        cy.contains('Title is a required field');
        cy.contains('Description is a required field');
        cy.contains('Body is a required field');
    });

    it('should remove title error message when valid data is entered', () => {
        // Arrange
        cy.get('.error-messages');
        cy.contains('Title is a required field');

        // Act
        cy.get('#create-post-title').type('Writing Integration Tests with Cypress').blur();

        // Assert
        cy.get('.error-messages');
        cy.contains('Title is a required field').should('not.exist');
    });

    it('should remove description error message when valid data is entered', () => {
        // Arrange
        cy.get('.error-messages');
        cy.contains('Description is a required field');

        // Act
        cy.get('#create-post-description').type('Using Blazor!').blur();

        // Assert
        cy.get('.error-messages');
        cy.get('Description is a required field').should('not.exist');
    });

    it('should remove body error message when valid data is entered', () => {
        // Arrange
        cy.get('.error-messages');
        cy.contains('Body is a required field');

        // Act
        cy.get('#create-post-body').type('Blazor is cool!').blur();

        // Assert
        cy.get('.error-messages').should('not.have.html');
    });

    it('should create the article and navigate to the article post page', () => {
        // Arrange
        cy.get('[type=submit]').click();

        // Act/Assert
        cy.get('#article-title').then(element => cy.contains(element.text()));
    });

    it('should edit the article title', () => {
        // Arrange
        const newTitle = 'Blazor is wicked cool!';
        cy.get('#article-edit-button').first().click();
        cy.contains('Publish Article');

        // Act
        cy.get('#edit-post-title').clear().type(newTitle);
        cy.get('[type=submit]').click();

        // Assert
        cy.get('#article-title').then(() => cy.contains(newTitle));
    });

    it('should delete the article and navigate back to the home page', () => {
        // Arrange/Act
        cy.get('#article-delete-button').first().click();

        // Assert
        cy.get('.logo-font');
        cy.contains('A place to share your knowledge.');
    })
});
