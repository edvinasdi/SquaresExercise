using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquaresAPI.Data;
using SquaresAPI.Data.Entities;
using SquaresAPI.Models.Request;
using SquaresAPI.Models.Response;
using SquaresAPI.Services;

namespace SquaresAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly ILogger<PlanesController> _logger;

        private readonly ApiDbContext _context;

        private readonly IMapper _mapper;

        public PlanesController(ILogger<PlanesController> logger, ApiDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "Get all Planes")]
        public async Task<IActionResult> Get()
        {
            var allPlanes = await _context.Planes.ToListAsync();

            return Ok(allPlanes);
        }

        [HttpPost(Name = "Import a Plane of Points")]
        public async Task<IActionResult> Post(ImportPlane importPlane)
        {
            var plane = new Plane();
            _context.Add(plane);
            await _context.SaveChangesAsync();

            var points = new List<Point>();
            foreach(var importPoint in importPlane.Points)
            {
                points.Add(new Point()
                {
                    X = importPoint.X,
                    Y = importPoint.Y,
                    Plane = plane,
                });
            }

            _context.Points.AddRange(points);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ImportedPlane>(plane);

            BackgroundJob.Enqueue<SquaresCalculatorService>(service => service.Calculate());

            return Ok(result);
        }
    }
}