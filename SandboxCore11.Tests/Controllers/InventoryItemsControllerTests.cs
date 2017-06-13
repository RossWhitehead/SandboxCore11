using SandboxCore11.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SandboxCore11.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;

namespace SandboxCore11.Tests.Controllers
{
    public class InventoryItemsControllerTests
    {
        private InventoryItemsController sut;
        private ApplicationDbContext db;
        private DbContextOptions<ApplicationDbContext> options;

        public InventoryItemsControllerTests()
        {
            this.options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "write")
                .Options;

            this.db = new ApplicationDbContext(options);

            this.sut = new InventoryItemsController(this.db);
        }

        [Fact]
        public void Index_ReturnsView()
        {
            // Arrange
            var expectedInventoryItems = CreateTestInventoryItems(this.db);

            // Action
            var result = this.sut.Index().Result as ViewResult;

            // Assert
            result.Should().BeOfType<ViewResult>();

            var vm = result.Model as List<InventoryItem>;

            vm.Should().BeOfType<List<InventoryItem>>();
            vm.ShouldAllBeEquivalentTo(expectedInventoryItems);
                
        }

        private static List<InventoryItem> CreateTestInventoryItems(ApplicationDbContext db)
        {
            var inventoryItems = new List<InventoryItem>()
            {
                new InventoryItem() { Id = 1, Name = "Item 1" },
                new InventoryItem() { Id = 2, Name = "Item 2" },
                new InventoryItem() { Id = 3, Name = "Item 3" }
            };

            db.AddRange(inventoryItems);

            db.SaveChanges();

            return inventoryItems;
        }
    }
}
