using AutoMapper;
using SquaresAPI.Data;
using SquaresAPI.Data.Entities;
using SquaresAPI.Data.Repositories;
using SquaresAPI.Models.Request;
using SquaresAPI.Models.Response;

namespace SquaresAPI.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly IPlaneRepository _planeRepository;

        private readonly IPointRepository _pointRepository;

        private readonly ISquareRepository _squareRepository;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ApiDbContext _context;

        public PlaneService(
            IPlaneRepository planeRepository,
            IPointRepository pointRepository,
            ISquareRepository squareRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ApiDbContext context)
        {
            _planeRepository = planeRepository;
            _pointRepository = pointRepository;
            _squareRepository = squareRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<PlaneWithPointsResponse> ImportPoints(PlaneRequest planeRequest)
        {
            var plane = await _planeRepository.AddPlaneAsync(new Plane());

            plane.Points = _mapper.Map<List<Point>>(planeRequest.Points);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<PlaneWithPointsResponse>(plane);
        }

        public async Task<Plane?> GetPlaneWithPointsAsync(Guid planeId)
        {
            return await _planeRepository.GetPlaneWithPointsAsync(planeId);
        }

        public async Task<PlaneWithPointsResponse?> AddPointToPlaneAsync(Guid planeId, PointRequest pointRequest)
        {
            Plane? plane = await _planeRepository.GetPlaneWithSquaresAsync(planeId);
            if (plane == null)
            {
                return null;
            }

            var point = _mapper.Map<Point>(pointRequest);

            plane.Points.Add(point);
            plane.Processed = false;
            plane.TotalSquares = 0;
            _squareRepository.RemoveRange(plane.Squares);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<PlaneWithPointsResponse?>(plane);
        }

        public async Task<PlaneWithPointsResponse?> DeletePointFromPlaneAsync(Guid pointId)
        {
            var point = await _pointRepository.DeletePointAsync(pointId);
            if (point == null)
            {
                return null;
            }

            var plane = await _planeRepository.GetPlaneAsync(point.PlaneId);
            if (plane == null)
            {
                return null;
            }

            plane.Processed = false;
            plane.TotalSquares = 0;
            _squareRepository.RemoveRange(plane.Squares);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<PlaneWithPointsResponse>(plane);
        }

        public async Task<PlaneWithPointsResponse?> GetPlaneAsync(Guid planeId)
        {
            var plane = await _planeRepository.GetPlaneWithPointsAsync(planeId);
            if (plane == null)
            {
                return null;
            }

            return _mapper.Map<PlaneWithPointsResponse>(plane);
        }

        public async Task<PlaneWithSquaresResponse?> GetPlaneSquaresWithSquarePoints(Guid planeId)
        {
            var plane = await _planeRepository.GetPlaneWithSquaresAndSquarePointsAsync(planeId);
            if (plane == null)
            {
                return null;
            }

            return _mapper.Map<PlaneWithSquaresResponse>(plane);
        }
    }
}
