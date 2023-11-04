using AutoMapper;
using Tracker.Api.Interfaces;
using Tracker.Api.Models;
using Tracker.Data.Models;
using Tracker.Data.Interfaces;

namespace Tracker.Api.Managers
{
    public class VehicleLocationManager : IVehicleLocationManager
    {
        private readonly IVehicleLocationRepository locationRepository;
        private readonly IMapper mapper;

        public VehicleLocationManager(IVehicleLocationRepository locationRepository, IMapper mapper)
        {
            this.locationRepository = locationRepository;
            this.mapper = mapper;
        }

        public IList<VehicleLocationDto> GetAllVehicleLocations()
        {
            IList<VehicleLocation> locations = locationRepository.GetAll();
            return mapper.Map<IList<VehicleLocationDto>>(locations);
        }

        public VehicleLocationDto? GetVehicleLocation(uint locationId)
        {
            VehicleLocation? location = locationRepository.FindById(locationId);

            if (location is null)
                return null;

            return mapper.Map<VehicleLocationDto>(location);
        }

        public VehicleLocationDto AddVehicleLocation(VehicleLocationDto locationDto)
        {
            VehicleLocation location = mapper.Map<VehicleLocation>(locationDto);
            location.LocationId = default;
            VehicleLocation addedLocation = locationRepository.Insert(location);

            return mapper.Map<VehicleLocationDto>(addedLocation);
        }

        public VehicleLocationDto? UpdateVehicleLocation(uint locationId, VehicleLocationDto locationDto)
        {
            if (!locationRepository.ExistsWithId(locationId))
                return null;

            VehicleLocation location = mapper.Map<VehicleLocation>(locationDto);
            location.LocationId = (uint)locationId;
            VehicleLocation updatedLocation = locationRepository.Update(location);

            return mapper.Map<VehicleLocationDto>(updatedLocation);
        }

        public VehicleLocationDto? DeleteVehicleLocation(uint locationId)
        {
            if (!locationRepository.ExistsWithId(locationId))
                return null;

            VehicleLocation location = locationRepository.FindById(locationId);
            VehicleLocationDto locationDto = mapper.Map<VehicleLocationDto>(location);

            // Provádíte další akce před smazáním polohy vozidla, pokud je to potřeba

            locationRepository.Delete(locationId);

            return locationDto;
        }
    }
}