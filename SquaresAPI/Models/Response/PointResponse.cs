using SquaresAPI.Models.Request;

namespace SquaresAPI.Models.Response
{
    public class PointResponse : PointRequest
    {
        public Guid Id { get; set; }
    }
}
