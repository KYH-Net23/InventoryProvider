using InventoryProvider.Contexts;
using InventoryProvider.Models;
using InventoryProvider.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProvider.Tests.Repositories
{
    public class InventoryRepositoryTests
    {
        private Mock<InventoryContext> _mockContext;
        private InventoryRepository _repository;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<InventoryContext>();
            _repository = new InventoryRepository(_mockContext.Object);
        }

        [Test]
        public async Task GetInventory_InventoryExists_ReturnsInventory()
        {
            // Arrange
            var product = new InventoryEntity { Id = 1, StoreName = "Prada Store" };
            _mockContext.Setup(c => c.Inventories.FindAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _repository.GetByIdAsync(product.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StoreName, Is.EqualTo("Prada Store"));
        }

        [Test]
        public async Task GetInventory_InventoryDoesNotExists_ReturnsNull()
        {
            // Arrange
            var productId = 1;
            _mockContext.Setup(c => c.Inventories.FindAsync(productId)).ReturnsAsync((InventoryEntity)null!);

            // Act
            var result = await _repository.GetByIdAsync(productId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task SaveAsync_SuccessfulChanges_ReturnsTrue()
        {
            // Arrange
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _repository.SaveAsync();

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task SaveAsync_NoChanges_Or_Error_ReturnsFalse()
        {
            // Arrange
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            // Act
            var result = await _repository.SaveAsync();

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
