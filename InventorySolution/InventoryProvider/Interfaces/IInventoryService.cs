using InventoryProvider.Models;

namespace InventoryProvider.Interfaces
{
    public interface IInventoryService
    {
        Task<List<InventoryEntity>> GetAllInventoriesAsync();
        Task<InventoryEntity?> GetInventoryByIdAsync(int id);
        Task<string> CreateInventoryAsync(InventoryModel model);
        Task<int> UpdateInventoryAsync(int id, InventoryModel model);
        Task<bool> DeleteInventoryAsync(int id);

    }
}
