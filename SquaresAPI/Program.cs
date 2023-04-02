using Microsoft.EntityFrameworkCore;
using SquaresAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// Update database
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
context.Database.Migrate();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
