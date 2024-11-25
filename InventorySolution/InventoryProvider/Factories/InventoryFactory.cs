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
                Location = inventory.Location,
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
                Location = model.Location,
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
            entity.Location = model.Location;
            entity.Description = model.Description;
            entity.Capacity = model.Capacity;
            entity.LastUpdatedDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
