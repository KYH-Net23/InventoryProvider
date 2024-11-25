using InventoryProvider.Models;

namespace InventoryProvider.Interfaces
{
    public interface IInventoryRepository
    {
        Task<List<InventoryEntity>> GetAllAsync();
        Task<InventoryEntity?> GetByIdAsync(int id);
        //Task<bool> DeleteAsync(int id);
    }
}
