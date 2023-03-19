using AutoMapper;
using backend.Interfaces;
using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.Car.Queries.GetlAllCars;

public sealed class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery,Page<GetAllCarsDto>>
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;

    public GetAllCarsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _carRepository = unitOfWork.Cars;   
    }
    public async Task<Page<GetAllCarsDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var pageRequest = PaginationHelper.Eval(request.PageRequestDto, new CarColumnSelector());
        var result = await _carRepository.GetAllAsync(pageRequest);
        return Page<GetAllCarsDto>.From(result, _mapper.Map<IEnumerable<GetAllCarsDto>>(result.Data));
    }
}