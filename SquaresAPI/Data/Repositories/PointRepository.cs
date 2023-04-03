using SquaresAPI.Data.Entities;

namespace SquaresAPI.Data.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly ApiDbContext _context;

        public PointRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Point>> AddPointRangeAsync(IEnumerable<Point> points)
        {
            await _context.Points.AddRangeAsync(points);

            return points;
        }

        public async Task<Point?> DeletePointAsync(Guid pointId)
        {
            var point = await _context.Points.FindAsync(pointId);
            if (point == null)
            {
                return null;
            }

            _context.Points.Remove(point);

            return point;
        }
    }
}
