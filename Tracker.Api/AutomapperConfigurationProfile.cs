using AutoMapper;
using Tracker.Api.Models;
using Tracker.Data.Models;

namespace Tracker.Api
{
    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Genre, string>()
                .ConstructUsing((genre, resolutionContext) => genre.Name);

            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.ActorIds, opt => opt.MapFrom(m => m.Actors.Select(p => p.PersonId).ToList()));
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Genres, opt => opt.Ignore())
                .ForMember(m => m.Actors, opt => opt.Ignore());

            CreateMap<Movie, ExtendedMovieDto>()
                .ForMember(m => m.ActorIds, opt => opt.MapFrom(m => m.Actors.Select(p => p.PersonId).ToList()));

            CreateMap<VehicleLocation, VehicleLocationDto>();
            CreateMap<VehicleLocationDto, VehicleLocation>();

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(m => m.LocationIds, opt => opt.MapFrom(m => m.Locations.Select(p => p.LocationId).ToList()));
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(m => m.Locations, opt => opt.Ignore());

          
        }
    }
}