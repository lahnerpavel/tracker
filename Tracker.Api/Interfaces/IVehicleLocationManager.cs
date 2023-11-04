using Tracker.Api.Models;
//using Tracker.Data.Models;

namespace Tracker.Api.Interfaces
{
    public interface IVehicleLocationManager
    {
        IList<VehicleLocationDto> GetAllVehicleLocations();
        VehicleLocationDto? GetVehicleLocation(uint locationId);
        VehicleLocationDto AddVehicleLocation(VehicleLocationDto locationDto);
        VehicleLocationDto? UpdateVehicleLocation(uint locationId, VehicleLocationDto locationDto);
        VehicleLocationDto? DeleteVehicleLocation(uint locationId);
    }
}