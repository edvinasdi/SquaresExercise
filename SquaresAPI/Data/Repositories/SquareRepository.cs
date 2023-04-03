using SquaresAPI.Data.Entities;

namespace SquaresAPI.Data.Repositories
{
    public class SquareRepository : ISquareRepository
    {
        private readonly ApiDbContext _context;

        public SquareRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void RemoveRange(ICollection<Square> squares)
        {
            _context.Squares.RemoveRange(squares);
        }
    }
}
