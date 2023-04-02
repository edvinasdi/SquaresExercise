using System.ComponentModel.DataAnnotations.Schema;

namespace SquaresAPI.Data.Entities
{
    public class Point : BaseEntity
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Guid PlaneId { get; set; }

        public Guid? SquareId { get; set; }

        public virtual Plane Plane { get; set; }

        public virtual Square? Square { get; set; }
    }
}
