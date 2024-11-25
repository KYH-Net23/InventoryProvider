using InventoryProvider.Contexts;
using InventoryProvider.Interfaces;
using InventoryProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryProvider.Repositories
{
    public class InventoryRepository(InventoryContext context) : IInventoryRepository
    {
        private readonly InventoryContext _context = context;

        public async Task<List<InventoryEntity>> GetAllAsync()
        {
            return await _context.Inventories.ToListAsync();
        }
        public async Task<InventoryEntity?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Inventories.FindAsync(id);
            }
            catch 
            { 
                return null!;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<InventoryEntity> SaveAsync(InventoryEntity entity)
        {
            try
            {
                entity.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
                await _context.Inventories.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch
            {
                return null!;
            }
        }

        public async Task<bool> DeleteAsync(InventoryEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            _context.Inventories.Remove(entity);
             var result = await SaveAsync();
            return result;
        }
    }
}
