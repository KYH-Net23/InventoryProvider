namespace InventoryProvider.ViewModels
{
    public class LocationViewModel
    {

        //public string FullAddress => $"{Country}, {StreetAddress}, {City}, {ZipCode}";
        public string Country {  get; set; }
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
    }
}
