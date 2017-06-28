namespace SandboxCore11.Tests.Controllers
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using SandboxCore11.Data;
    using SandboxCore11.Features.InventoryItems;
    using SandboxCore11.Tests.Builders;
    using Xunit;

    public class InventoryItemsControllerTests
    {
        private InventoryItemsController sut;
        private List<InventoryItem> expectedInventoryItems;

        public InventoryItemsControllerTests()
        {
            this.expectedInventoryItems = CreateTestInventoryItems();
            this.sut = new InventoryItemsController(null, null);
        }

        [Fact]
        public void Index_ReturnsView()
        {
            //// Arrange
     
            //// Action
            //var result = this.sut.Index().Result as ViewResult;

            //// Assert
            //result.Should().BeOfType<ViewResult>();

            //var actualInventoryItems = result.Model as List<InventoryItem>;

            //actualInventoryItems.Should().BeOfType<List<InventoryItem>>();
            //actualInventoryItems.ShouldAllBeEquivalentTo(expectedInventoryItems);               
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
