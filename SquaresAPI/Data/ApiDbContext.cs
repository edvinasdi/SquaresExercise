using Microsoft.EntityFrameworkCore;
using SquaresAPI.Data.Entities;

namespace SquaresAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Square> Squares { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plane>(entityTypeBuilder =>
            {
                entityTypeBuilder
                    .HasMany(plane => plane.Points)
                    .WithOne(point => point.Plane)
                    .HasForeignKey(point => point.PlaneId)
                    .HasConstraintName("FK_Plane_Point");

                entityTypeBuilder
                    .HasMany(plane => plane.Squares)
                    .WithOne(square => square.Plane)
                    .HasForeignKey(square => square.PlaneId)
                    .HasConstraintName("FK_Plane_Square");
            });

            modelBuilder.Entity<Square>(entityTypeBuilder =>
            {
                entityTypeBuilder
                    .HasMany(square => square.Points)
                    .WithOne(point => point.Square)
                    .HasConstraintName("FK_Square_Point")
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
