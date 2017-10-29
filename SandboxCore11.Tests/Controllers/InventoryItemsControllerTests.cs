namespace SandboxCore11.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using FixtureBuilder;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using SandboxCore11.Features.InventoryItems;
    using SandboxCore11.Infrastructure.Query;
    using SandboxCore11.Queries;
    using Xunit;

    public class InventoryItemsControllerTests
    {
        private InventoryItemsController sut;
        private Mock<IMapper> mockMapper;

        public InventoryItemsControllerTests()
        {
            mockMapper = new Mock<IMapper>();
            sut = new InventoryItemsController(mockMapper.Object, null);
        }

        /// <summary>
        /// Index action returns view.
        /// </summary>
        [Fact]
        public void Index_ReturnsView()
        {
            // Arrange
            var expectedInventoryItems = CreateTestInventoryItems();
            var mockQueryHandler = new Mock<IQueryHandlerAsync<InventoryItemsQuery, List<InventoryItem>>>();
            mockQueryHandler.Setup(x => x.HandleAsync(It.IsAny<InventoryItemsQuery>())).ReturnsAsync(expectedInventoryItems);

            // Action
            var result = this.sut.Index(mockQueryHandler.Object).Result as ViewResult;

            // Assert
            result.Should().BeOfType<ViewResult>();

            var actualInventoryItems = result.Model as List<InventoryItem>;

            actualInventoryItems.Should().BeOfType<List<InventoryItem>>();
            actualInventoryItems.ShouldAllBeEquivalentTo(expectedInventoryItems);
        }

        /// <summary>
        /// Details action returns view - happy path
        /// </summary>
        [Fact]
        public void Details_ReturnsView()
        {
            // Arrange
            var expectedInventoryItem = CreateTestInventoryItems()[0];

            var queryFixture = new InventoryItemQuery() { InventoryItemId = expectedInventoryItem.InventoryItemId };

            var expectedViewModel = new Fixture().Create<DetailsViewModel>();

            //var expectedViewModel = new DetailsViewModel()
            //{
            //    InventoryItemId = 1,
            //    Brand = default(Guid).ToString(),
            //    Category = default(Guid).ToString(),
            //    Description = default(Guid).ToString(),
            //    Name = default(Guid).ToString(),
            //    ReorderLevel = 2,
            //    ReorderQuantity = 3
            //};

            var mockQueryHandler = new Mock<IQueryHandlerAsync<InventoryItemQuery, InventoryItem>>();
            mockQueryHandler.Setup(x => x.HandleAsync(queryFixture)).ReturnsAsync(expectedInventoryItem);

            mockMapper.Setup(x => x.Map<DetailsViewModel>(expectedInventoryItem)).Returns(expectedViewModel);

            // Action
            var result = this.sut.Details(mockQueryHandler.Object, queryFixture).Result as ViewResult;

            // Assert
            result.Should().BeOfType<ViewResult>();

            var actualViewModel = result.Model as DetailsViewModel;

            actualViewModel.Should().BeOfType<DetailsViewModel>();
            actualViewModel.ShouldBeEquivalentTo(expectedViewModel);
        }

        /// <summary>
        /// Details actioin returns not found when the requested inventory item does not exist - unhappy path
        /// </summary>
        [Fact]
        public void Details_ReturnsNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var queryFixture = new InventoryItemQuery() { InventoryItemId = 1 };

            var mockQueryHandler = new Mock<IQueryHandlerAsync<InventoryItemQuery, InventoryItem>>();
            mockQueryHandler.Setup(x => x.HandleAsync(queryFixture)).ReturnsAsync((InventoryItem)null);

            // Action
            var result = this.sut.Details(mockQueryHandler.Object, queryFixture).Result as NotFoundResult;

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        private static List<InventoryItem> CreateTestInventoryItems()
        {
            var inventoryItems = new List<InventoryItem>()
            {
                new InventoryItem() { InventoryItemId = 1, Name = "Item 1" },
                new InventoryItem() { InventoryItemId = 2, Name = "Item 2" },
                new InventoryItem() { InventoryItemId = 3, Name = "Item 3" }
            };

            return inventoryItems;
        }
    }
}
