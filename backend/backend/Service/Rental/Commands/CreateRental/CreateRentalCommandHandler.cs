using AutoMapper;
using backend.Exceptions;
using backend.Interfaces;
using backend.Models;
using MediatR;

namespace backend.Service.Rental.Commands.CreateRental;

public sealed class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreateRentalDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarRepository _carRepository;
    private readonly IRentalPointRepository _rentalPointRepository;
    private readonly IRentalRepository _rentalRepository;
    private readonly IMapper _mapper;

    public CreateRentalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _carRepository = unitOfWork.Cars;
        _rentalRepository = unitOfWork.Rentals;
        _rentalPointRepository = unitOfWork.RentalPoints;
    }
    public async Task<CreateRentalDto> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var startPoint = await _rentalPointRepository.GetRentalPointByName(request.StartRentalPointName)
                         ?? throw new NotFoundException($"Rental point {request.StartRentalPointName} not found");
        
        var endPoint = await _rentalPointRepository.GetRentalPointByName(request.EndRentalPointName)
                         ?? throw new NotFoundException($"Rental point {request.EndRentalPointName} not found");
        
        var car = await _carRepository.GetCarByModelAndRentalPointId(request.CarModel, startPoint.Id)
                         ?? throw new NotFoundException($"Car {request.CarModel} from {startPoint.RentalPointName} not found");
        
        if (!await _carRepository.IsCarAvailable(request.CarModel, startPoint.Id))
        {
            throw new ConflictException("This car is no available now");
        }
        
        var daysOfRent = request.RentalDateEnd - DateTime.Now;
        
        
        var rental = new Entity.Rental
        {
            FirstName = request.FirstName,
            Surname = request.Surname,
            PeselNumber = request.PeselNumber,
            ContactNumber = request.ContactNumber,
            Nationality = request.Nationality,
            Gender = request.Gender,
            RentalDateStart = DateTime.Now,
            RentalDateEnd = request.RentalDateEnd,
            TotalCostOfRent = car.CostPerDay * daysOfRent.Days,
            CarId = car.Id,
            StartRentalPointId = startPoint.Id,
            EndRentalPointId = endPoint.Id
        };
        _rentalRepository.Add(rental);
        
        car.Available = false;
        car.RentalPointId = endPoint.Id;
        
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CreateRentalDto>(rental);
    }
}