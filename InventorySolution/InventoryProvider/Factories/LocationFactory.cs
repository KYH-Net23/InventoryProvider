using InventoryProvider.Models;
using InventoryProvider.ViewModels;

namespace InventoryProvider.Factories
{
    public class LocationFactory
    {
        public static LocationViewModel CreateLocationViewModel(Location location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));

            return new LocationViewModel
            {
                Country = location.Country,
                StreetAddress = location.StreetAddress,
                City = location.City,
                ZipCode = location.ZipCode
            };
        }

        public static Location CreateLocationModel(LocationModel location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));

            return new Location
            {
                Country = location.Country,
                StreetAddress = location.StreetAddress,
                City = location.City,
                ZipCode = location.ZipCode
            };
        }
    }
}
