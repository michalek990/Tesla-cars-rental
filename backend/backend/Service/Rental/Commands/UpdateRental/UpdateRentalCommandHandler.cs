using AutoMapper;
using backend.Exceptions;
using backend.Interfaces;
using backend.Models;
using MediatR;

namespace backend.Service.Rental.Commands.UpdateRental;

public sealed class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, UpdateRentalDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarRepository _carRepository;
    private readonly IRentalPointRepository _rentalPointRepository;
    private readonly IRentalRepository _rentalRepository;
    private readonly IMapper _mapper;

    public UpdateRentalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _carRepository = unitOfWork.Cars;
        _rentalRepository = unitOfWork.Rentals;
        _rentalPointRepository = unitOfWork.RentalPoints;
    }
    
    public async Task<UpdateRentalDto> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
    {
        var rental = await _rentalRepository.GetByPeselCarModelAndEndRentalPoint(request.PeselNumber, request.Model, request.EndRentalPoint)
                        ?? throw new NotFoundException($"Rental not found with car {request.Model} in point {request.EndRentalPoint}");

        var newCostForRent = request.UpdateRentalDto!.RentalDateEnd - rental.RentalDateStart;
        
        rental.FirstName = request.UpdateRentalDto!.FirstName;
        rental.Surname = request.UpdateRentalDto!.Surname;
        rental.RentalDateEnd = request.UpdateRentalDto!.RentalDateEnd;
        rental.TotalCostOfRent = 125.0 * newCostForRent.Days;

        await _unitOfWork.SaveAsync();

        return _mapper.Map<UpdateRentalDto>(rental);
    }
}