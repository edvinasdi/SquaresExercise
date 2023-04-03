using SquaresAPI.Data.Entities;
using SquaresAPI.Models.Request;
using SquaresAPI.Models.Response;

namespace SquaresAPI.Services
{
    public interface IPlaneService
    {
        public Task<PlaneWithPointsResponse?> AddPointToPlaneAsync(Guid planeId, PointRequest pointRequest);
        public Task<PlaneWithPointsResponse?> DeletePointFromPlaneAsync(Guid pointId);
        public Task<PlaneWithPointsResponse?> GetPlaneAsync(Guid planeId);
        public Task<PlaneWithSquaresResponse?> GetPlaneSquaresWithSquarePoints(Guid planeId);
        public Task<PlaneWithPointsResponse> ImportPoints(PlaneRequest plane);
    }
}
