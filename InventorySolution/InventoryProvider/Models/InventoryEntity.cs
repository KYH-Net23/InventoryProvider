using System.ComponentModel.DataAnnotations;

namespace InventoryProvider.Models
{
    public class InventoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Inventory Name is required.")]
        public string? InventoryName { get; set; }

        [Required(ErrorMessage = "Store Name is required.")]
        public string StoreName { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        public Location Location { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Capacity must have a positive number.")]
        [Required]
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? LastUpdatedDate { get; set; }
    }
}
