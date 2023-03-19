using MediatR;

namespace backend.Service.Rental.Commands.DeleteRental;

public sealed record DeleteRentalCommand(string PeselNumber, string Model, string EndRentalPoint) : IRequest<Unit>;