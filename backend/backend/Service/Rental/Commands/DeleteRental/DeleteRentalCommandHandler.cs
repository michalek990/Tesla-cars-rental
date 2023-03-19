using backend.Exceptions;
using backend.Interfaces;
using MediatR;

namespace backend.Service.Rental.Commands.DeleteRental;

public sealed class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRentalRepository _rentalRepository;
    private readonly IRentalPointRepository _rentalPointRepository;
    private readonly ICarRepository _carRepository;

    public DeleteRentalCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _rentalRepository = unitOfWork.Rentals;
        _rentalPointRepository = unitOfWork.RentalPoints;
        _carRepository = unitOfWork.Cars;
    }
    public async Task<Unit> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
    {
        var rental = await _rentalRepository.GetByPeselCarModelAndEndRentalPoint(request.PeselNumber, request.Model, request.EndRentalPoint)
                     ?? throw new NotFoundException($"Rental not found with car {request.Model} in point {request.EndRentalPoint}");
        
        var endPoint = await _rentalPointRepository.GetRentalPointByName(request.EndRentalPoint)
                         ?? throw new NotFoundException($"Rental point {request.EndRentalPoint} not found");
        
        var car = await _carRepository.GetCarByModelAndRentalPointId(request.Model, endPoint.Id)
                  ?? throw new NotFoundException($"Car {request.Model} from {endPoint.RentalPointName} not found");
        
        _rentalRepository.Remove(rental);

        car.Available = true;
        car.RentalPointId = endPoint.Id;
        
        await _unitOfWork.SaveAsync();
        
        return Unit.Value;
    }
}