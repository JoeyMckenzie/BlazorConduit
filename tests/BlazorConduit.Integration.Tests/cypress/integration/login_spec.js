describe('Login page', () => {
    it('should display error messages on invalid form submit', () => {
        // Arrange
        cy.visit('/');
        cy.contains('Sign In').click();

        // Act
        cy.get('[type=submit]').click();

        // Assert
        cy.get('.error-messages');
        cy.contains('Email is required');
        cy.contains('Password is required');
    });

    it('should remove email error message when valid data is entered', () => {
        // Arrange
        cy.get('.error-messages');
        cy.contains('Email is required');

        // Act
        cy.get('#login-email-field').type('test@gmail.com').blur();

        // Assert
        cy.get('.error-messages');
        cy.contains('Email is required').should('not.exist');
    });

    it('should remove password error message when valid data is entered', () => {
        // Arrange
        cy.get('.error-messages');
        cy.contains('Password is required');

        // Act
        cy.get('#login-password-field').type('test12345').blur();

        // Assert
        cy.get('.error-messages').should('not.have.html');
        cy.get('Password is required').should('not.exist');
    });

    it('should display API errors on validation exceptions', () => {
        // Arrange
        cy.get('.error-messages').should('not.have.html');

        // Act
        cy.get('[type=submit]').click();

        // Assert
        cy.get('.error-messages');
        cy.contains('email or password is invalid');
    });

    it('should proceed to login and redirect the user on a valid sign in', () => {
        // Arrange
        const email = Cypress.env('email')
        const password = Cypress.env('password')

        // Act
        cy.get('#login-email-field').clear().type(email);
        cy.get('#login-password-field').clear().type(password);
        cy.get('[type=submit]').click();

        // Assert, wait for redirect to finish
        cy.wait(1500);
        cy.get('.logo-font');
        cy.contains('A place to share your knowledge.');
    });
});
