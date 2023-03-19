using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.Car.Queries.GetCarsByRentalPoint;

public sealed record GetCarsByRentalPointQuery(string rentalPointName, PageRequestDto PageRequestDto) : IRequest<Page<GetCarByRentalPointDto>>;
