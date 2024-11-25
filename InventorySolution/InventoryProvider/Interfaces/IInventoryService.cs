using InventoryProvider.Models;

namespace InventoryProvider.Interfaces
{
    public interface IInventoryService
    {
        Task<List<InventoryModel>> GetAllInventoriesAsync();
        Task<InventoryModel?> GetInventoryByIdAsync(int id);
        Task<InventoryModel> CreateInventoryAsync(InventoryModel model);
        //Task<InventoryModel> UpdateInventoryAsync();
        //Task<bool> DeleteInventoryAsync(int id); 
 
    }
}
