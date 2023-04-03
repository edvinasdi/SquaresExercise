using System.ComponentModel.DataAnnotations;

namespace SquaresAPI.Data.Entities
{
    public class Square : BaseEntity
    {
        public Square() { }

        public Square(ICollection<Point> points)
        {
            Points = points;
        }

        public Guid? PlaneId { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public virtual ICollection<Point> Points { get; set; }

        public virtual Plane? Plane { get; set; }
    }
}
