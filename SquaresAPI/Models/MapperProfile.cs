using AutoMapper;
using SquaresAPI.Data.Entities;
using SquaresAPI.Models.Request;
using SquaresAPI.Models.Response;

namespace SquaresAPI.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Plane, ImportedPlane>();
            CreateMap<Point, ImportedPoint>();
        }
    }
}
