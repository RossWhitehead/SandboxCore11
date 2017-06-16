# SandboxCore11
Sandbox for playing with ASP.NET Core 1.1

Here's what I've done so far -

## Feature folders
- I've moved the controllers, views, and view models into feature folders. I much prefer this way of working as it brings related code together in one place, and avoids lots of uneccessary navigation between controller, view, and model folders.
- It is necessary to tell the razor view engine to look for views in the feature folders. Here's a good article by Scott Sauber on how to do this - [Feature folder structure in asp net core](https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/)  

## xUnit unit tests
- I've added an xUnit test project. 
- I'm using Moq to generate mocks. However, I've not been successful in mocking the EF DbContext, so instead I'm using the Microsoft.EntityFrameworkCore.InMemory in memory database provider. So not trully isolating the units of code from the dependency. But it's good enough.
- I'm using the fluent api builder pattern to build fixtures (AutoFixture doesn't appear to have been ported to .NET Core as of writing). I'm also using this pattern to build the DbContext test double - see Builders/ApplicationDbContextBuilder.cs.
- And I'm using the FluentAssertions library, partly because it improves the readability of the code and allows for chaining of assertions. But also because it has the ShouldAllBeEquivalentTo method that does a value comparison between 2 object graphs. So no need to roll my own comparison code.

## GitHub to Azure continuous integration
- I'm hosting the site as a web service on Windows Azure.
- I've set up continuous integration between the Master branch on GitHub and Windows Azure. 
- So when I merge code into Master, it gets deployed to Azure, built, unit tested, and output artifacts get created.
- It was realtively simple to set up. Much more so than when I last tried, and failed miserably, during the early beta days of .NET Core.
