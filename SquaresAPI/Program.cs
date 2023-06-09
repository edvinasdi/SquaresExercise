using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SquaresAPI.BackgroundProcessing;
using SquaresAPI.Data;
using SquaresAPI.Data.Repositories;
using SquaresAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SquaresDatabase");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Dependency injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPlaneService, PlaneService>();
builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();
builder.Services.AddScoped<IPointRepository, PointRepository>();
builder.Services.AddScoped<ISquareRepository, SquareRepository>();
builder.Services.AddScoped<IDatabaseStatusRepository, DatabaseStatusRepository>();

// Configure and add Hangfire for background processing
builder.Services.AddHangfire((sp, config) =>
{
    config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
    config.UseMemoryStorage();
});
builder.Services.AddHangfireServer();

var app = builder.Build();

// Update database
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
context.Database.Migrate();

app.UseHangfireDashboard(
    "/hangfire", 
    new DashboardOptions() { Authorization = new[] { new DashboardNoAuthFilter() } });

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
