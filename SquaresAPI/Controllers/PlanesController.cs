using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using SquaresAPI.Models.Request;
using SquaresAPI.Models.Response;
using SquaresAPI.Services;

namespace SquaresAPI.Controllers
{
    [ApiController]
    [Route("planes")]
    public class PlanesController : ControllerBase
    {
        private readonly IPlaneService _planeService;

        public PlanesController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        [HttpPost("/planes")]
        public async Task<IActionResult> ImportPoints(PlaneRequest planeRequest)
        {
            var planeResponse = await _planeService.ImportPoints(planeRequest);

            BackgroundJob.Enqueue<SquaresCalculatorService>(service => service.CalculatePlaneSquares(planeResponse.Id));

            return Ok(planeResponse);
        }

        [HttpPost("/planes/{planeId:guid}/points")]
        public async Task<IActionResult> AddPointToPlane([FromRoute] Guid planeId, PointRequest pointRequest)
        {
            var result = await _planeService.AddPointToPlaneAsync(planeId, pointRequest);
            if (result == null)
            {
                return BadRequest($"Plane with Id=\"{planeId}\" was not found");
            }

            BackgroundJob.Enqueue<SquaresCalculatorService>(service => service.CalculatePlaneSquares(planeId));

            return Ok(result);
        }

        [HttpDelete("/planes/points/{pointId:guid}")]
        public async Task<IActionResult> DeletePointFromPlane([FromRoute] Guid pointId)
        {
            PlaneWithPointsResponse? plane = await _planeService.DeletePointFromPlaneAsync(pointId);
            if (plane == null)
            {
                return BadRequest($"Point with Id=\"{pointId}\" was not found");
            }

            BackgroundJob.Enqueue<SquaresCalculatorService>(service => service.CalculatePlaneSquares(plane.Id));

            return Ok(plane);
        }

        [HttpGet("{planeId:guid}")]
        public async Task<IActionResult> GetPlaneWithPoints([FromRoute] Guid planeId)
        {
            PlaneWithPointsResponse? plane = await _planeService.GetPlaneAsync(planeId);
            if (plane == null)
            {
                return BadRequest($"Plane with Id=\"{planeId}\" was not found");
            }

            return Ok(plane);
        }

        [HttpGet("/planes/{planeId:guid}/squares")]
        public async Task<IActionResult> GetPlaneSquares([FromRoute] Guid planeId)
        {
            var plane = await _planeService.GetPlaneSquaresWithSquarePoints(planeId);

            if (plane == null)
            {
                return BadRequest($"Plane with Id=\"{planeId}\" was not found");
            }

            if (!plane.Processed)
            {
                return Accepted($"Plane with Id=\"{planeId}\" exists but it's squares are not identified yet. Try again later.");
            }

            return Ok(plane);
        }
    }
}