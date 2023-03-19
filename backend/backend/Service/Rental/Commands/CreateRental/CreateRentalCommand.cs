using backend.Models;
using MediatR;

namespace backend.Service.Rental.Commands.CreateRental;

public sealed record CreateRentalCommand(
    string FirstName,
    string Surname,
    string PeselNumber,
    int ContactNumber,
    Nationality Nationality,
    Gender Gender,
    DateTime RentalDateEnd,
    string CarModel,
    string StartRentalPointName,
    string EndRentalPointName) : IRequest<CreateRentalDto>;