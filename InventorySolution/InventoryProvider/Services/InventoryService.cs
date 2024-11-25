using InventoryProvider.Factories;
using InventoryProvider.Interfaces;
using InventoryProvider.Models;
using InventoryProvider.Repositories;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InventoryProvider.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly List<InventoryModel> _inventory = new();
        private readonly InventoryRepository? _repository;
        public Task<List<InventoryModel>> GetAllInventoriesAsync()
        {
            return Task.FromResult(_inventory);
        }
        public Task<InventoryModel?> GetInventoryByIdAsync(int id)
        {
            var inventory = _inventory.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(inventory);
        }
        public async Task<InventoryModel> CreateInventoryAsync(InventoryModel model)
        {
            try
            {
                var entity = InventoryFactory.CreateInventory(model);
                entity.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
                try
                {
                    var result = await _repository.SaveAsync(entity);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch
            {
                return null!;
            }

            return model;
        }
        //public Task<InventoryModel> UpdateInventoryAsync()
        //{

        //    return;
        //}

        //public Task<bool> DeleteInventoryAsync(int id)
        //{
        //    return;
        //}
    }
}
