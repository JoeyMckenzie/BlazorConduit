![Realworld logo](./realworld-logo.png)

> ### Blazor WebAssembly codebase containing real world examples (CRUD, auth, advanced patterns, etc) that adheres to the [RealWorld](https://github.com/gothinkster/realworld) spec and API.

### [Demo](https://blazor-conduit.netlify.app/)&nbsp;&nbsp;&nbsp;&nbsp;[RealWorld](https://github.com/gothinkster/realworld)

[![Build Status](https://dev.azure.com/JoeyMckenzie/Blazor%20Conduit/_apis/build/status/JoeyMckenzie.BlazorConduit?branchName=master)](https://dev.azure.com/JoeyMckenzie/Blazor%20Conduit/_build/latest?definitionId=9&branchName=master)
[![Netlify Status](https://api.netlify.com/api/v1/badges/f9c217ee-5425-4b53-a44b-de89d3e90e74/deploy-status)](https://app.netlify.com/sites/blazor-portfolio/deploys)
![Azure Static Web Apps CI/CD](https://github.com/JoeyMckenzie/BlazorConduit/workflows/Azure%20Static%20Web%20Apps%20CI/CD/badge.svg)


This codebase was created to demonstrate a fully fledged fullstack application built with Blazor WebAssembly including CRUD operations, authentication, routing, pagination, and more.

We've gone to great lengths to adhere to the Blazor WebAssembly community styleguides & best practices.

For more information on how to this works with other frontends/backends, head over to the [RealWorld](https://github.com/gothinkster/realworld) repo.

# How it works

This application is written according to the RealWorld frontend spec using [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor). Following Blazor best practices, I decided to rely heavily on [Fluxor](https://github.com/mrpmorris/fluxor) utilizing redux throughout the application. For those new to Blazor, I would suggest reading the getting start docs from Microsoft before jumping into the codebase.

# Getting started
1. Clone/fork this repository
2. Ensure you have the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/download) installed (make sure you have the version used within `global.json`)
3. `cd` into the `BlazorConduit.Client` project folder and run `dotnet watch run`
4. The application should now be serving to `https://localhost:5001`

#### Testing
I use [cypress](https://www.cypress.io/) for integration and end-to-end testing, with plans of eventually adding [bUnit](https://github.com/rafritts/bunit) tests at some point. To run the tests:
1. `cd` into the test project `BlazorConduit.Integration.Tests`
2. Ensure you have `npm` installed
3. Run `npm install --save-dev`
4. Cypress should now be installed, fire it up with `npx cypress open` from within the test project directory
5. In the cypress window, you should now see all the spec files and be able to run them

