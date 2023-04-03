using Microsoft.EntityFrameworkCore;
using SquaresAPI.Data.Entities;
using SquaresAPI.Models.Request;

namespace SquaresAPI.Data.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly ApiDbContext _context;

        public PlaneRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Plane> AddPlaneAsync(Plane plane)
        {
            await _context.Planes.AddAsync(plane);
            return plane;
        }

        public async Task<Plane?> GetPlaneAsync(Guid planeId)
        {
            var result = await _context.Planes
                .Include(p => p.Points)
                .Include(p => p.Squares)
                .FirstOrDefaultAsync(p => p.Id == planeId);

            if (result == default)
            {
                return null;
            }

            return result;
        }

        public async Task<Plane?> GetPlaneWithPointsAsync(Guid planeId)
        {
            var result = await _context.Planes.Include(p => p.Points).FirstOrDefaultAsync(p => p.Id == planeId);

            if (result == default)
            {
                return null;
            }

            return result;
        }

        public async Task<Plane?> GetPlaneWithSquaresAsync(Guid planeId)
        {
            var result = await _context.Planes.Include(p => p.Squares).FirstOrDefaultAsync(p => p.Id == planeId);

            if (result == default)
            {
                return null;
            }

            return result;
        }

        public async Task<Plane?> GetPlaneWithSquaresAndSquarePointsAsync(Guid planeId)
        {
            var result = await _context.Planes
                .Include(p => p.Squares)
                .ThenInclude(s => s.Points)
                .FirstOrDefaultAsync(p => p.Id == planeId);

            if (result == default)
            {
                return null;
            }

            return result;
        }
    }
}
