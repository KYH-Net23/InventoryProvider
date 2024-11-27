namespace InventoryProvider.Models
{
    public class LocationModel
    {
        public string Country { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
    }
}
