using Tracker.Api.Models;
using Tracker.Data.Models;

namespace Tracker.Api.Interfaces
{
    public interface IVehicleManager
    {
        IList<VehicleDto> GetAllVehicles();
        VehicleDto? GetVehicle(uint vehicleId);
        VehicleDto AddVehicle(VehicleDto vehicleDto);
        VehicleDto? UpdateVehicle(uint vehicleId, VehicleDto vehicleDto);
        VehicleDto? DeleteVehicle(uint vehicleId);
    }
}