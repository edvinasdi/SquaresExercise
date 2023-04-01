using Microsoft.EntityFrameworkCore;
using SquaresAPI.Data.Entities;

namespace SquaresAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Point> Points { get; set; }
    }
}
