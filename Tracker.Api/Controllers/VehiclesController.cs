using Microsoft.AspNetCore.Mvc;
using Tracker.Api.Interfaces;
using Tracker.Api.Models;
//using Tracker.Data.Models;

namespace Tracker.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleManager vehicleManager;

        public VehiclesController(IVehicleManager vehicleManager)
        {
            this.vehicleManager = vehicleManager;
        }


        [HttpGet("vehicles")]
        public IEnumerable<VehicleDto> GetVehicles()
        {
            return vehicleManager.GetAllVehicles();
        }

        [HttpGet("vehicles/{vehicleId}")]
        public IActionResult GetVehicle(uint vehicleId)
        {
            VehicleDto? vehicle = vehicleManager.GetVehicle(vehicleId);

            if (vehicle is null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpPost("vehicles")]
        public IActionResult AddVehicle([FromBody] VehicleDto vehicle)
        {
            VehicleDto? createdVehicle = vehicleManager.AddVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicle), new { vehicleId = createdVehicle.VehicleId }, createdVehicle);
        }

        [HttpPut("vehicles/{vehicleId}")]
        public IActionResult EditVehicle(uint vehicleId, [FromBody] VehicleDto vehicle)
        {
            VehicleDto? updatedVehicle = vehicleManager.UpdateVehicle(vehicleId, vehicle);

            if (updatedVehicle is null)
                return NotFound();

            return Ok(updatedVehicle);
        }

        [HttpDelete("vehicles/{vehicleId}")]
        public IActionResult DeleteVehicle(uint vehicleId)
        {
            VehicleDto? deletedVehicle = vehicleManager.DeleteVehicle(vehicleId);

            if (deletedVehicle is null)
                return NotFound();

            return Ok(deletedVehicle);
        }
    }
}