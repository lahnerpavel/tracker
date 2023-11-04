using AutoMapper;
using Tracker.Api.Models;
using Tracker.Data.Models;

namespace Tracker.Api
{
    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {

            CreateMap<VehicleLocation, VehicleLocationDto>();
            CreateMap<VehicleLocationDto, VehicleLocation>();

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(m => m.LocationIds, opt => opt.MapFrom(m => m.Locations.Select(p => p.LocationId).ToList()));
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(m => m.Locations, opt => opt.Ignore());

        }
    }
}