using AutoMapper;
using SquaresAPI.Data.Entities;
using SquaresAPI.Models.Request;
using SquaresAPI.Models.Response;

namespace SquaresAPI.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Plane, PlaneWithPointsResponse>();
            CreateMap<Point, PointResponse>();
            CreateMap<PointRequest, Point>();
            CreateMap<Plane, PlaneWithSquaresResponse>();
            CreateMap<Square, SquareResponse>();
        }
    }
}
