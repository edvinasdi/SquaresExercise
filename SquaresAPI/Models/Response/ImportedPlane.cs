using SquaresAPI.Models.Request;

namespace SquaresAPI.Models.Response
{
    public class ImportedPlane
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<ImportedPoint> Points { get; set; }
    }
}
