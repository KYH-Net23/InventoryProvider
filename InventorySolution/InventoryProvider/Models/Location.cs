using System.ComponentModel.DataAnnotations;

namespace InventoryProvider.Models
{
    public class Location
    {
        [Required]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "Street Address is required.")]
        public string StreetAddress { get; set; } = null!;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Zip Code is required.")]
        [RegularExpression(@"^\d{5}(?:-\d{4})?$", ErrorMessage = "Invalid Zip Code format.")]
        public string ZipCode { get; set; } = null!;
    }
}
