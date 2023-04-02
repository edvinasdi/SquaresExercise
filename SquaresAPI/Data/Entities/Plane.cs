namespace SquaresAPI.Data.Entities
{
    public class Plane : BaseEntity
    {
        public Plane()
        {
            Points = new HashSet<Point>();
            Squares = new List<Square>();
        }

        public bool Processed { get; set; }

        public int TotalSquares { get; set; }

        public virtual ICollection<Point> Points { get; set; }

        public virtual ICollection<Square> Squares { get; set; }
    }
}
