using System.ComponentModel.DataAnnotations;

namespace InventoryProvider.ViewModels
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public string? InventoryName { get; set; }
        public string? StoreName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
    }
}
