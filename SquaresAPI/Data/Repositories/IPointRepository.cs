using SquaresAPI.Data.Entities;

namespace SquaresAPI.Data.Repositories
{
    public interface IPointRepository
    {
        public Task<Point?> DeletePointAsync(Guid pointId);
    }
}
