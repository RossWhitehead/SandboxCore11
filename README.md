# SandboxCore11
Sandbox for playing with ASP.NET Core 1.1

Here's what I've done so far -

## Feature folders
- I've move the controllers, views, and view models into feature folders. I much prefer this way of working as it brings related code together in one place, and avoids lots of uneccessary navigation between controller, view, and model folders.
- It is necessary to tell the razor view engine to locate for views in the feature folders. Here's a good article by Scott Sauber on how to do this - [Feature folder structure in asp net core](https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/)  

## xUnit unit tests
- I've added an xUnit test project. 
- I'm using Moq to generate mocks. However, i've not been successful in mocking the EF DbContext, so instead I'm using the Microsoft.EntityFrameworkCore.InMemory in memory database provider. So not trully isolating the units of code from the dependency. But it's good enough for now.
- I'm using the fluent api builder pattern to build fixtures (AutoFixture doesn't appear to have been ported to .NET Core as of writting). I'm also using this to build the DbContext test double - see Builders/ApplicationDbContextBuilder.cs.
- And I'm using the FluentAssertions library, partly because it improves the readability of the code and allows for chaining of assertions. But also because it has the ShouldAllBeEquivalentTo method that does a value comparison between 2 object graphs. So no need to roll my own comparison code.
