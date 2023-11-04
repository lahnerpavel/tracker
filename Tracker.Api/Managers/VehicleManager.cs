using AutoMapper;
using Tracker.Api.Interfaces;
using Tracker.Api.Models;
using Tracker.Data.Models;
using Tracker.Data.Interfaces;

namespace Tracker.Api.Managers
{
    public class VehicleManager : IVehicleManager
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IMapper mapper;

        public VehicleManager(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
        }


        public IList<VehicleDto> GetAllVehicles()
        {
            IList<Vehicle> vehicles = vehicleRepository.GetAll();
            return mapper.Map<IList<VehicleDto>>(vehicles);
        }

        public VehicleDto? GetVehicle(uint vehicleId)
        {
            Vehicle? vehicle = vehicleRepository.FindById(vehicleId);

            if (vehicle is null)
                return null;

            return mapper.Map<VehicleDto>(vehicle);
        }

        public VehicleDto AddVehicle(VehicleDto vehicleDto)
        {
            Vehicle vehicle = mapper.Map<Vehicle>(vehicleDto);
            vehicle.VehicleId = default;
            Vehicle addedVehicle = vehicleRepository.Insert(vehicle);

            return mapper.Map<VehicleDto>(addedVehicle);
        }

        public VehicleDto? UpdateVehicle(uint vehicleId, VehicleDto vehicleDto)
        {
            if (!vehicleRepository.ExistsWithId(vehicleId))
                return null;

            Vehicle vehicle = mapper.Map<Vehicle>(vehicleDto);
            vehicle.VehicleId = vehicleId;
            Vehicle updatedVehicle = vehicleRepository.Update(vehicle);

            return mapper.Map<VehicleDto>(updatedVehicle);
        }

        public VehicleDto? DeleteVehicle(uint vehicleId)
        {
            if (!vehicleRepository.ExistsWithId(vehicleId))
                return null;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Vehicle vehicle = vehicleRepository.FindById(vehicleId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            VehicleDto vehicleDto = mapper.Map<VehicleDto>(vehicle);

            // Provádíte další akce před smazáním vozidla, pokud je to potřeba

            vehicleRepository.Delete(vehicleId);

            return vehicleDto;
        }
    }
}