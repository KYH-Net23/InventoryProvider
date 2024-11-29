using InventoryProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryProvider.Contexts
{
    public class InventoryContext : DbContext
    {

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        public virtual DbSet<InventoryEntity> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}
