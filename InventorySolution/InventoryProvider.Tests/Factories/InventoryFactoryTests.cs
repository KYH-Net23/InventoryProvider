using InventoryProvider.Factories;
using InventoryProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProvider.Tests.Factories
{
    public class InventoryFactoryTests
    {
        [Test]
        public void Create_ShouldMapAllProperties()
        {
            //Arrange
            var inventoryModel = new InventoryModel()
            {
                InventoryName = "Test name",
                StoreName = "Test store",
                Location = new LocationModel 
                { 
                    Country = "Sweden", 
                    City = "Stockholm", 
                    StreetAddress = "Gata 1", 
                    ZipCode = "111 11"
                },
                Description = "Test description",
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            //Act
            var result = InventoryFactory.CreateInventory(inventoryModel);
            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(result.InventoryName, Is.EqualTo(inventoryModel.InventoryName));
                Assert.That(result.StoreName, Is.EqualTo(inventoryModel.StoreName));

                // Location
                Assert.That(result.Location.Country, Is.EqualTo(inventoryModel.Location.Country));
                Assert.That(result.Location.City, Is.EqualTo(inventoryModel.Location.City));
                Assert.That(result.Location.StreetAddress, Is.EqualTo(inventoryModel.Location.StreetAddress));
                Assert.That(result.Location.ZipCode, Is.EqualTo(inventoryModel.Location.ZipCode));

                Assert.That(result.Description, Is.EqualTo(inventoryModel.Description));
                Assert.That(result.CreatedDate, Is.EqualTo(inventoryModel.CreatedDate));
            });
        }

        [Test]
        public void Create_ReturnsInventoryEntity_WhenGivenInventoryModel()
        {
            // Arrange
            var model = new InventoryModel
            {
                InventoryName = "Test name",
                StoreName = "Test store",
                Location = new LocationModel
                {
                    Country = "Sweden",
                    City = "Stockholm",
                    StreetAddress = "Gata 1",
                    ZipCode = "111 11"
                },
                Description = "Test description",
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            // Act
            var entity = InventoryFactory.CreateInventory(model);

            // Assert
            Assert.That(entity, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(entity.InventoryName, Is.EqualTo(model.InventoryName));
                Assert.That(entity.StoreName, Is.EqualTo(model.StoreName));

                // location
                Assert.That(entity.Location.Country, Is.EqualTo(model.Location.Country));
                Assert.That(entity.Location.StreetAddress, Is.EqualTo(model.Location.StreetAddress));
                Assert.That(entity.Location.City, Is.EqualTo(model.Location.City));
                Assert.That(entity.Location.ZipCode, Is.EqualTo(model.Location.ZipCode));

                Assert.That(entity.Description, Is.EqualTo(model.Description));
                Assert.That(entity.CreatedDate, Is.EqualTo(model.CreatedDate));
            });
        }

        [Test]
        public void GetInventories_ShouldMapListOfInventoryEntitiesToListOfInventoryViewModels()
        {
            var inventoryEntities = new List<InventoryEntity>
            {
                new() 
                { 
                    Id = 1, InventoryName = "Name1", 
                    StoreName = "Store1",
                    Location = new Location
                    {
                        Country = "Sweden",
                        City = "Stockholm",
                        StreetAddress = "Gata 1",
                        ZipCode = "111 11"
                    },
                    Description = "Description1", 
                    Capacity = 1000 
                },
                new() 
                { 
                    Id = 1, InventoryName = "Name2", 
                    StoreName = "Store2",
                    Location = new Location
                    {
                        Country = "Sweden",
                        City = "Stockholm",
                        StreetAddress = "Gata 1",
                        ZipCode = "111 11"
                    },
                    Description = "Description2", 
                    Capacity = 500 
                }
            };

            var inventoryViewModels = InventoryFactory.GetInventories(inventoryEntities);

            Assert.That(inventoryViewModels.Count, Is.EqualTo(inventoryEntities.Count));
            for (int i = 0; i < inventoryEntities.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(inventoryViewModels[i].Id, Is.EqualTo(inventoryEntities[i].Id));
                    Assert.That(inventoryViewModels[i].StoreName, Is.EqualTo(inventoryEntities[i].StoreName));

                    // Location
                    Assert.That(inventoryViewModels[i].Location.Country, Is.EqualTo(inventoryEntities[i].Location.Country));
                    Assert.That(inventoryViewModels[i].Location.City, Is.EqualTo(inventoryEntities[i].Location.City));
                    Assert.That(inventoryViewModels[i].Location.StreetAddress, Is.EqualTo(inventoryEntities[i].Location.StreetAddress));
                    Assert.That(inventoryViewModels[i].Location.ZipCode, Is.EqualTo(inventoryEntities[i].Location.ZipCode));

                    Assert.That(inventoryViewModels[i].Description, Is.EqualTo(inventoryEntities[i].Description));
                    Assert.That(inventoryViewModels[i].Capacity, Is.EqualTo(inventoryEntities[i].Capacity));
                });
            }
        }

        [Test]
        public void MapExistingEntityFromModel_UpdatesEntity_WhenGivenInventoryModel()
        {
            // Arrange
            var existingEntity = new InventoryEntity
            {
                InventoryName = "Big inventory",
                StoreName = "Clothing Store",
                Location = new Location
                {
                    Country = "Sweden",
                    City = "Stockholm",
                    StreetAddress = "Gata 1",
                    ZipCode = "111 11"
                },
                Description = "A big inventory.",
                Capacity = 1500,
                IsActive = false,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            var model = new InventoryModel
            {
                InventoryName = "Bigger Inventory",
                StoreName = "Electronics Store",
                Location = new LocationModel
                {
                    Country = "Sweden",
                    City = "Stockholm",
                    StreetAddress = "Gata 1",
                    ZipCode = "111 11"
                },
                Description = "A very big inventory.",
                Capacity = 10000,
                IsActive = true,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)
            };

            // Act
            InventoryFactory.MapExistingEntityFromModel(ref existingEntity, model);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(existingEntity.InventoryName, Is.EqualTo(model.InventoryName));
                Assert.That(existingEntity.StoreName, Is.EqualTo(model.StoreName));

                // Location
                Assert.That(existingEntity.Location.Country, Is.EqualTo(model.Location.Country));
                Assert.That(existingEntity.Location.City, Is.EqualTo(model.Location.City));
                Assert.That(existingEntity.Location.StreetAddress, Is.EqualTo(model.Location.StreetAddress));
                Assert.That(existingEntity.Location.ZipCode, Is.EqualTo(model.Location.ZipCode));

                Assert.That(existingEntity.Description, Is.EqualTo(model.Description));
                Assert.That(existingEntity.Capacity, Is.EqualTo(model.Capacity));
                Assert.That(existingEntity.IsActive, Is.EqualTo(model.IsActive));
                Assert.That(existingEntity.CreatedDate, Is.EqualTo(model.CreatedDate));

            });
        }
    }
}
