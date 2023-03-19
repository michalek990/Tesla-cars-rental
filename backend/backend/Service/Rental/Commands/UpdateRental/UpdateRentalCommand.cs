using backend.Models;
using MediatR;

namespace backend.Service.Rental.Commands.UpdateRental;

public sealed record UpdateRentalCommand(string PeselNumber, string Model, string EndRentalPoint, UpdateRentalDto UpdateRentalDto) : IRequest<UpdateRentalDto>;