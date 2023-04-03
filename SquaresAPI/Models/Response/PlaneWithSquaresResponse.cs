using SquaresAPI.Models.Request;

namespace SquaresAPI.Models.Response
{
    public class PlaneWithSquaresResponse
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public int TotalSquares { get; set; }

        public bool Processed { get; set; }

        public List<SquareResponse> Squares { get; set; }
    }
}
