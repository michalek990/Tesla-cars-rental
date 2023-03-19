using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.Car.Queries.GetlAllCars;

public sealed record GetAllCarsQuery(PageRequestDto PageRequestDto) : IRequest<Page<GetAllCarsDto>>;
