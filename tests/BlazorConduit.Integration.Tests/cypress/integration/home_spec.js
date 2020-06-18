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
});
