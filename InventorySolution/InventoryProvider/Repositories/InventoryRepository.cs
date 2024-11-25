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

        //public Task<bool> DeleteAsync(int id)
        //{
        //    return;
        //}
    }
}
