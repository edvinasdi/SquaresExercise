using SquaresAPI.Data.Entities;

namespace SquaresAPI.Data.Repositories
{
    public interface ISquareRepository
    {
        public void RemoveRange(ICollection<Square> squares);
    }
}
