using AutoMapper;
using backend.Exceptions;
using backend.Interfaces;
using backend.Models;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.Car.Queries.GetCarsByRentalPoint;

public sealed class GetCarsByRentalPointQueryHandler : IRequestHandler<GetCarsByRentalPointQuery, Page<GetCarByRentalPointDto>>
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly IRentalPointRepository _rentalPointRepository;

    public GetCarsByRentalPointQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _carRepository = unitOfWork.Cars;
        _rentalPointRepository = unitOfWork.RentalPoints;
    }
    
    public async Task<Page<GetCarByRentalPointDto>> Handle(GetCarsByRentalPointQuery request, CancellationToken cancellationToken)
    {
        var rentalPoint = await _rentalPointRepository.GetRentalPointByName(request.rentalPointName)
                          ?? throw new NotFoundException($"Rental point {request.rentalPointName} not found");

        var pageRequest = PaginationHelper.Eval(request.PageRequestDto, new CarColumnSelector());
        var result = await _carRepository.GetCarsFromRentalPoint(rentalPoint.Id, pageRequest);
        return Page<GetCarByRentalPointDto>.From(result, _mapper.Map<IEnumerable<GetCarByRentalPointDto>>(result.Data));
    }
}