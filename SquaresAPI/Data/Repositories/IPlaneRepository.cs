using SquaresAPI.Data.Entities;
using SquaresAPI.Models.Request;

namespace SquaresAPI.Data.Repositories
{
    public interface IPlaneRepository
    {
        public Task<Plane> AddPlaneAsync(Plane plane);
        public Task<Plane?> GetPlaneWithPointsAsync(Guid planeId);

        public Task<Plane?> GetPlaneWithSquaresAsync(Guid planeId);

        public Task<Plane?> GetPlaneWithSquaresAndSquarePointsAsync(Guid planeId);

        public Task<Plane?> GetPlaneAsync(Guid planeId);
    }
}
