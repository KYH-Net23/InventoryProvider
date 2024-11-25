using System.ComponentModel.DataAnnotations;

namespace InventoryProvider.Models
{
    public class InventoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inventory Name is required.")]
        [StringLength(100, ErrorMessage = "Inventory Name cannot exceed 100 characters.")]
        public string? InventoryName { get; set; }

        [Required(ErrorMessage = "Store Name is required.")]
        [StringLength(50, ErrorMessage = "Store Name cannot exceed 50 characters.")]
        public string StoreName { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        public string Location {  get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Capacity must have a positive number.")]
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? LastUpdatedDate { get; set; }

    }
}
