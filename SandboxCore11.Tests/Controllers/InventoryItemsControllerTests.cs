using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SandboxCore11.Data;
using SandboxCore11.Features.InventoryItems;
using SandboxCore11.Tests.Builders;
using System.Collections.Generic;
using Xunit;

namespace SandboxCore11.Tests.Controllers
{
    public class InventoryItemsControllerTests
    {
        private InventoryItemsController sut;
        private List<InventoryItem> expectedInventoryItems;

        public InventoryItemsControllerTests()
        {
            this.expectedInventoryItems = CreateTestInventoryItems();
            var db = new ApplicationDbContextBuilder().WithInventoryItems(expectedInventoryItems);
            this.sut = new InventoryItemsController(db, null);
        }

        [Fact]
        public void Index_ReturnsView()
        {
            // Arrange
     
            // Action
            var result = this.sut.Index().Result as ViewResult;

            // Assert
            result.Should().BeOfType<ViewResult>();

            var actualInventoryItems = result.Model as List<InventoryItem>;

            actualInventoryItems.Should().BeOfType<List<InventoryItem>>();
            actualInventoryItems.ShouldAllBeEquivalentTo(expectedInventoryItems);               
        }

        private static List<InventoryItem> CreateTestInventoryItems()
        {
            var inventoryItems = new List<InventoryItem>()
            {
                new InventoryItem() { Id = 1, Name = "Item 1" },
                new InventoryItem() { Id = 2, Name = "Item 2" },
                new InventoryItem() { Id = 3, Name = "Item 3" }
            };

            return inventoryItems;
        }
    }
}
