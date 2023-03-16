using AutoMapper;
using backend.Interfaces;
using backend.Models;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.Rental.Queries.GetlAllRentals;

public sealed class GetAllRentalsQueryHandler : IRequestHandler<GetAllRentalsQuery, Page<GetAllRentalsDto>>
{
    private readonly IMapper _mapper;
    private readonly IRentalRepository _rentalRepository;

    public GetAllRentalsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _rentalRepository = unitOfWork.Rentals;
    }

    public async Task<Page<GetAllRentalsDto>> Handle(GetAllRentalsQuery request, CancellationToken cancellationToken)
    {
        var pageRequest = PaginationHelper.Eval(request.PageRequestDto, new RentalsColumnSelector());
        var result = await _rentalRepository.GetAllAsync(pageRequest);
        return Page<GetAllRentalsDto>.From(result, _mapper.Map<IEnumerable<GetAllRentalsDto>>(result.Data));
    }
    
}