using AutoMapper;
using backend.Interfaces;
using backend.Models;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.RentalPoint.Queries.GetAllRentalPoints;

public sealed class GetAllRentalPointsQueryHandler : IRequestHandler<GetAllRentalPointsQuery, Page<GetAllRentalPointsDto>>
{
    private readonly IMapper _mapper;
    private readonly IRentalPointRepository _rentalPointRepository;

    public GetAllRentalPointsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _rentalPointRepository = unitOfWork.RentalPoints;
    }
    
    public async Task<Page<GetAllRentalPointsDto>> Handle(GetAllRentalPointsQuery request, CancellationToken cancellationToken)
    {
        var pageRequest = PaginationHelper.Eval(request.PageRequestDto, new RentalPointColumnSelector());
        var result = await _rentalPointRepository.GetAllAsync(pageRequest);
        return Page<GetAllRentalPointsDto>.From(result, _mapper.Map<IEnumerable<GetAllRentalPointsDto>>(result.Data));
    }
}