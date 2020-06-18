/// <reference types='Cypress' />

const apiUrl = Cypress.env('apiUrl')
const email = Cypress.env('email')
const password = Cypress.env('password')
const username = Cypress.env('username')
const token = Cypress.env('token')

const post = (urlFragment, body) => cy.request({
        'method': 'POST',
        'url': `${apiUrl}${urlFragment}`,
        'headers': { 'Authorization': `Token ${token}` },
        'body': body
    });

// describe('Secured operations', () => {
//     beforeEach(() =>  window.localStorage.setItem('jwt', token));

//     describe('Editor', () => {
//         it.only('Submits an article', () => {
//             cy.visit('/');

//             // Submit article
//             cy.contains('New Post').click();

//             cy.get('input').eq(0).type('Blazor Realworld test article');
//             cy.get('input').eq(1).type('Description');
//             cy.get('input').eq(2).type('testing blazor');
//             cy.get('textarea').first().type('# Article body');

//             cy.contains('Publish Article').click();
//             cy.contains('Blazor Realworld test article');

//             cy.url().then(articleUrl => {
//                 // Edit article
//                 cy.contains('Edit Article').click();

//                 cy.get('input').eq(0).as('titleInput');
//                 cy.get('@titleInput').should('have.value', 'Blazor Realworld test article');
//                 cy.get('@titleInput').clear();
//                 cy.get('@titleInput').type('Blazor Realworld edited article');
//                 cy.contains('Publish Article').click();

//                 // Wait until article has been updated
//                 cy.contains('Edit Article');

//                 // Check edited article
//                 cy.visit(articleUrl);
//                 cy.contains('Blazor Realworld edited article');
//                 cy.get('.article-content h1').first().should('contain', 'Article body');

//                 // Delete article
//                 cy.contains('Delete Article').click();

//                 // Verify we're back on the Home page
//                 cy.contains('Global Feed');
//             })
//         });
//     });

//     describe('Profile', () => {
//         it('Shows my name and articles', () => {
//             const articleBody = {
//                 article: {
//                     title: 'Blazor Realworld profile test',
//                     description: 'Description',
//                     body: 'Body',
//                     tagList: [
//                         'blazor', 
//                         'testing'
//                     ]
//                 }
//             };

//             post('/articles', JSON.stringify(articleBody))
//                 .then(response => {
//                     const slug = response.body.article.slug;

//                     cy.visit('/');

//                     // Wait until logged in
//                     cy.get('.nav-link .user-pic');

//                     // Go to profile
//                     cy.get('.nav').contains(username).click();
//                     cy.get('.user-info').contains(username);
//                     cy.contains('Blazor Realworld profile test').click({ force: true });

//                     // Delete article
//                     cy.contains('Delete Article').click();
//                 });
//         });
//     });
// });