using SquaresAPI.Models.Request;

namespace SquaresAPI.Models.Response
{
    public class PlaneWithPointsResponse
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public List<PointResponse> Points { get; set; }
    }
}
