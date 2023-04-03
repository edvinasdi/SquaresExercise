using SquaresAPI.Data.Entities;
using SquaresAPI.Data.Repositories;

namespace SquaresAPI.Services
{
    public class SquaresCalculatorService
    {

        private readonly IPlaneRepository _planeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public SquaresCalculatorService(IPlaneRepository planeRepository, IUnitOfWork unitOfWork)
        {
            _planeRepository = planeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CalculatePlaneSquares(Guid PlaneId)
        {
            var plane = await _planeRepository.GetPlaneWithPointsAsync(PlaneId);

            if (plane == default)
            {
                // Normally better handling would be here
                return;
            }

            // Probably should've used DTOs as parameters to SquareCount function
            var squares = SquareCount(plane.Points.ToArray());

            plane.TotalSquares = squares.Count();
            plane.Squares = squares;
            plane.Processed = true;

            await _unitOfWork.CompleteAsync();
        }

        public List<Square> SquareCount(Point[] input)
        {
            int count = 0;
            var squares = new List<Square>();

            HashSet<Point> set = new HashSet<Point>();
            foreach (var point in input)
                set.Add(point);

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i == j || input[i].X == input[j].X || input[i].Y == input[j].Y)
                        continue;
                    //For each Point i, Point j, check if b&d exist in set.
                    Point[] DiagVertex = GetRestPoints(input[i], input[j]);
                    if (set.Any(p => p.X == DiagVertex[0].X && p.Y == DiagVertex[0].Y) 
                        && set.Any(p => p.X == DiagVertex[1].X && p.Y == DiagVertex[1].Y))
                    {
                        count++;

                        List<Point> points = new List<Point>();
                        var a = set.FirstOrDefault(p => p.X == input[i].X && p.Y == input[i].Y);
                        if (a != null)
                        {
                            set.Remove(a);
                            points.Add(a);
                        }
                        var c = set.FirstOrDefault(p => p.X == input[j].X && p.Y == input[j].Y);
                        if (c != null)
                        {
                            set.Remove(c);
                            points.Add(c);
                        }
                        var b = set.First(p => p.X == DiagVertex[0].X && p.Y == DiagVertex[0].Y);
                        if (b != null)
                        {
                            set.Remove(b);
                            points.Add(b);
                        }
                        var d = set.First(p => p.X == DiagVertex[1].X && p.Y == DiagVertex[1].Y);
                        if(d != null)
                        {
                            set.Remove(d);
                            points.Add(d);
                        }

                        squares.Add(new Square(points));
                    }
                }
            }

            return squares;
        }

        private Point[] GetRestPoints(Point a, Point c)
        {
            Point[] res = new Point[2];

            int bX = (a.X + c.X + a.Y - c.Y) / 2;
            int bY = (c.X - a.X + a.Y + c.Y) / 2;
            int dX = (a.X + c.X + c.Y - a.Y) / 2;
            int dY = (a.X - c.X + a.Y + c.Y) / 2;

            res[0] = new Point(bX, bY);
            res[1] = new Point(dX, dY);

            return res;
        }
    }
}
