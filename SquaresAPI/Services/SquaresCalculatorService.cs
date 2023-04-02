using SquaresAPI.Data;
using SquaresAPI.Data.Entities;

namespace SquaresAPI.Services
{
    public class SquaresCalculatorService
    {
        IServiceProvider _serviceProvider;

        ApiDbContext _context;

        public SquaresCalculatorService(ApiDbContext context)
        {
            _context = context;
        }

        public void Calculate()
        {
            var plane = new Plane();
            _context.Planes.Add(plane);

            Thread.Sleep(5000);

            _context.SaveChanges();
        }
    }
}
