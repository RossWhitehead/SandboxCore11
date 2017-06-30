# SandboxCore11
Sandbox for playing with ASP.NET Core 1.1

Here's what I've done so far -

## Feature folders
- I've moved the controllers, views, and view models into feature folders. I much prefer this way of working as it brings related code together in one place, and avoids lots of uneccessary navigation between controller, view, and model folders.
- It is necessary to tell the razor view engine to look for views in the feature folders. Here's a good article by Scott Sauber on how to do this - [Feature folder structure in asp net core](https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/)  

## xUnit unit tests with Moq and FluentAssertions
- I've added an xUnit test project. 
- I'm using Moq to generate mocks. However, I've not been successful in mocking the EF DbContext, so instead I'm using the Microsoft.EntityFrameworkCore.InMemory in memory database provider. So not trully isolating the units of code from the dependency. But it's good enough.
- I'm using the fluent api builder pattern to build fixtures (AutoFixture doesn't appear to have been ported to .NET Core as of writing). I'm also using this pattern to build the DbContext test double - see Builders/ApplicationDbContextBuilder.cs.
- And I'm using the FluentAssertions library, partly because it improves the readability of the code and allows for chaining of assertions. But also because it has the ShouldAllBeEquivalentTo method that does a value comparison between 2 object graphs. So no need to roll my own comparison code.

## CQRS
- I've implemented the ubiquitous CQRS pattern with commands, command handlers, queries, and query handlers.
- The commands and queries share a single data context. So it is neither optimized for command nor queries. I may seperate the data context at some juncture. My primary reason for implementing CQRS in this case is not performance, but seperation of concerns and DRY. It beats referencing the data context directly from the controllers as the interface hides the data implementation details, and also a command or query can be untilised in different places in the application without repeating the logic. It also beats the ubiquitous repository. In any decent sized application, assuming that the repository isn't relenting control of the query by exposing IQueryables to the client (please no!), a repository can become bloated and unwieldy IMO.

## Validating commands with FluentValidation
- I'm using [FluentValidation.AspNetCore](https://www.nuget.org/packages/FluentValidation.AspNetCore/) to validate commands. Each command that requires validating has CommandValidator that is injected into the CommandHandler. The command is validated prior to executing the command. If invalid then a validation exception is raised.  

## GitHub to Azure continuous integration
- I'm hosting the site as a web service on Windows Azure.
- I've set up continuous integration between the Master branch on GitHub and Windows Azure. 
- So when I merge code into Master, it gets deployed to Azure, built, unit tested, and output artifacts get created.
- It was realtively simple to set up. Much more so than when I last tried, and failed miserably, during the early beta days of .NET Core.

##Typescript






