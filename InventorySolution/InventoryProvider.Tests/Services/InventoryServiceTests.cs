using InventoryProvider.Factories;
using InventoryProvider.Interfaces;
using InventoryProvider.Models;
using InventoryProvider.Responses;
using InventoryProvider.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProvider.Tests.Services
{
    public class InventoryServiceTests
    {
        private Mock<IInventoryRepository> _mockRepo;
        private InventoryService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IInventoryRepository>();
            _service = new InventoryService(_mockRepo.Object);
        }


        [Test]
        public async Task CreateInventoryAsync_WhenSaveIsSuccessful_ReturnsSuccess()
        {
            // Arrange
            var inventoryModel = new InventoryModel();
            var inventoryEntity = InventoryFactory.CreateInventory(inventoryModel);
            inventoryEntity.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            _mockRepo
                .Setup(repo => repo.SaveAsync(It.IsAny<InventoryEntity>()))
                .ReturnsAsync("Success");


            // Act
            var result = await _service.CreateInventoryAsync(inventoryModel);

            // Assert
            Assert.That(result, Is.EqualTo(ResultResponse.Success));
            _mockRepo.Verify(repo => repo.SaveAsync(It.IsAny<InventoryEntity>()), Times.Once);
        }

        [Test]
        public async Task GetInventoryById_ShouldGetCorrectId()
        {
            // Arrange
            var expectedInventory = new InventoryEntity { Id = 1 };

            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(expectedInventory);

            // Act
            var result = await _service.GetInventoryByIdAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task GetInventoryById_ShouldReturnNullWhenNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((InventoryEntity?)null!);

            // Act
            var result = await _service.GetInventoryByIdAsync(999);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task DeleteInventoryAsync_InventoryExistsAndGetsDeleted_ReturnsTrue()
        {
            // Arrange
            var inventory = new InventoryEntity { Id = 1 };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(inventory);
            _mockRepo.Setup(repo => repo.DeleteAsync(inventory)).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteInventoryAsync(1);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task UpdateInventoryAsync_InventoryUpdatedSuccessfully_ReturnsOne()
        {
            //Arrange
            var InventoryModel = new InventoryModel
            {
                InventoryName = "Test name",
                StoreName = "Test store",
                Location = "Test location",
                Description = "Test description",
                LastUpdatedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            var existingInventoryEntity = new InventoryEntity
            {
                Id = 1,
                StoreName = "Clothing Store",
            };

            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingInventoryEntity);
            _mockRepo.Setup(repo => repo.SaveAsync()).ReturnsAsync(true);

            //Act
            var result = await _service.UpdateInventoryAsync(1, InventoryModel);

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task UpdateInventoryAsync_InventoryNotFound_ReturnsZero()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((InventoryEntity?)null);

            //Act
            var result = await _service.UpdateInventoryAsync(1, new InventoryModel());

            //Assert
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public async Task UpdateInventoryAsync_SaveAsyncFails_ReturnZero()
        {
            //Arrange
            var inventoryModel = new InventoryModel
            {
                InventoryName = "Test name",
                StoreName = "Test store",
                Location = "Test location",
                Description = "Test description",
                LastUpdatedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            var existingInventoryEntity = new InventoryEntity
            {
                Id = 1,
                StoreName = "Test name"
            };

            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingInventoryEntity);
            _mockRepo.Setup(repo => repo.SaveAsync()).ReturnsAsync(false);

            //Act 
            var result = await _service.UpdateInventoryAsync(1, inventoryModel);

            //Assert 
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
