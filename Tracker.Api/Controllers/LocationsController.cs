using Microsoft.AspNetCore.Mvc;
using Tracker.Api.Interfaces;
using Tracker.Api.Models;
//using Tracker.Data.Models;

namespace Tracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IVehicleLocationManager locationManager;

        public LocationsController(IVehicleLocationManager locationManager)
        {
            this.locationManager = locationManager;
        }


        [HttpGet]
        public IEnumerable<VehicleLocationDto> GetVehicleLocations()
        {
            return locationManager.GetAllVehicleLocations();
        }

        [HttpGet("{locationId}")]
        public IActionResult GetVehicleLocation(uint locationId)
        {
            VehicleLocationDto? location = locationManager.GetVehicleLocation(locationId);

            if (location is null)
                return NotFound();

            return Ok(location);
        }

        [HttpPost]
        public IActionResult AddVehicleLocation([FromBody] VehicleLocationDto location)
        {
            VehicleLocationDto? createdLocation = locationManager.AddVehicleLocation(location);
            return CreatedAtAction(nameof(GetVehicleLocation), new { locationId = createdLocation.LocationId }, createdLocation);
        }

        [HttpPut("{locationId}")]
        public IActionResult EditVehicleLocation(uint locationId, [FromBody] VehicleLocationDto location)
        {
            VehicleLocationDto? updatedLocation = locationManager.UpdateVehicleLocation(locationId, location);

            if (updatedLocation is null)
                return NotFound();

            return Ok(updatedLocation);
        }

        [HttpDelete("{locationId}")]
        public IActionResult DeleteVehicleLocation(uint locationId)
        {
            VehicleLocationDto? deletedLocation = locationManager.DeleteVehicleLocation(locationId);

            if (deletedLocation is null)
                return NotFound();

            return Ok(deletedLocation);
        }
    }
}