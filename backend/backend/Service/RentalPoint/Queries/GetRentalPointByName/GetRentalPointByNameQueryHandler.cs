using AutoMapper;
using backend.Exceptions;
using backend.Interfaces;
using backend.Models;
using MediatR;

namespace backend.Service.RentalPoint.Queries.GetRentalPointByName;

public sealed class GetRentalPointByNameQueryHandler : IRequestHandler<GetRentalPointByNameQuery, GetAllRentalPointsDto>
{
    private readonly IMapper _mapper;
    private readonly IRentalPointRepository _rentalPointRepository;

    public GetRentalPointByNameQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _rentalPointRepository = unitOfWork.RentalPoints;
    }
    
    public async Task<GetAllRentalPointsDto> Handle(GetRentalPointByNameQuery request, CancellationToken cancellationToken)
    {
        var rentalPoint = await _rentalPointRepository.GetRentalPointByName(request.rentalPointName)
                          ?? throw new NotFoundException($"Rental point {request.rentalPointName} not found");

        return _mapper.Map<GetAllRentalPointsDto>(rentalPoint);
    }
}