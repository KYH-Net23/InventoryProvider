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
        public async Task<List<InventoryModel>> GetAllInventoriesAsync()
        {
            return await Task.FromResult(_inventory);
        }
        public async Task<InventoryModel?> GetInventoryByIdAsync(int id)
        {
            var inventory = _inventory.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(inventory);
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
        public async Task<int> UpdateInventoryAsync(int id, InventoryModel model)
        {
            try
            {
                int statuscode = 1;
                var existingInventory = await _repository.GetByIdAsync(id);

                if (existingInventory != null)
                {
                    InventoryFactory.MapExistingEntityFromModel(ref existingInventory, model);
                    var result = await _repository.SaveAsync();

                    if(result)
                    {
                        statuscode = 1;
                    }
                    else
                    {
                        statuscode = 0;
                    }

                }
                return statuscode;
            }
            catch 
            {
                return 2;
            }
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var inventory = await _repository.GetByIdAsync(id);
            if (inventory == null)
            {
                return false;
            }
            var result = await _repository.DeleteAsync(inventory);

            return result;
        }
    }
}
