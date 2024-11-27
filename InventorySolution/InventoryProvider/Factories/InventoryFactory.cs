using InventoryProvider.Models;
using InventoryProvider.ViewModels;
using Microsoft.Identity.Client;

namespace InventoryProvider.Factories
{
    public static class InventoryFactory
    {
        public static List<InventoryViewModel> GetInventories(List<InventoryEntity> inventories)
        {
            return inventories.Select(GetInventory).ToList();
        }

        public static InventoryViewModel GetInventory(InventoryEntity inventory)
        {
            return new InventoryViewModel
            {
                Id = inventory.Id,
                InventoryName = inventory.InventoryName,
                StoreName = inventory.StoreName,
                Location = LocationFactory.CreateLocationViewModel(inventory.Location),
                Description = inventory.Description,
                Capacity = inventory.Capacity,

            };
        }
        public static InventoryEntity CreateInventory(InventoryModel model)
        {
            return new InventoryEntity
            {
                InventoryName = model.InventoryName,
                StoreName = model.StoreName,
                Location = LocationFactory.CreateLocationModel(model.Location),
                Description = model.Description,
                Capacity = model.Capacity,
                IsActive = model.IsActive,
                CreatedDate = model.CreatedDate,
            };
        }

        public static void MapExistingEntityFromModel(ref InventoryEntity entity, InventoryModel model)
        {
            entity.InventoryName = model.InventoryName;
            entity.StoreName = model.StoreName;
            if (entity.Location == null)
            {
                entity.Location = new Location();
            }
            entity.Location.Country = model.Location.Country;
            entity.Location.StreetAddress = model.Location.StreetAddress;
            entity.Location.City = model.Location.City;
            entity.Location.ZipCode = model.Location.ZipCode;

            entity.Description = model.Description;
            entity.Capacity = model.Capacity;
            entity.IsActive = model.IsActive;
            entity.LastUpdatedDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
