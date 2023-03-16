using backend.Models;
using MediatR;

namespace backend.Service.RentalPoint.Queries.GetRentalPointByName;

public sealed record GetRentalPointByNameQuery(string rentalPointName) : IRequest<GetAllRentalPointsDto>;