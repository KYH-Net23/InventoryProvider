using InventoryProvider.Factories;
using InventoryProvider.Interfaces;
using InventoryProvider.Models;
using InventoryProvider.Repositories;
using InventoryProvider.Responses;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InventoryProvider.Services
{
    public class InventoryService(IInventoryRepository repository) : IInventoryService
    {
        private readonly List<InventoryModel> _inventory = new();
        private readonly IInventoryRepository? _repository = repository;

        public async Task<List<InventoryModel>> GetAllInventoriesAsync()
        {
            return await Task.FromResult(_inventory);
        }
        public async Task<InventoryEntity?> GetInventoryByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<string> CreateInventoryAsync(InventoryModel model)
        {
            try
            {
                var entity = InventoryFactory.CreateInventory(model);
                entity.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
                try
                {
                    var result = await _repository.SaveAsync(entity);
                    return ResultResponse.Success;
                }
                catch 
                {
                    return ResultResponse.Failed;
                }
            }
            catch
            {
                return ResultResponse.Failed;
            }
        }
        public async Task<int> UpdateInventoryAsync(int id, InventoryModel model)
        {
            try
            {
                int statuscode = -1;
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
