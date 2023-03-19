using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.Rental.Queries.GetlAllRentals;

public sealed record GetAllRentalsQuery(PageRequestDto PageRequestDto) : IRequest<Page<GetAllRentalsDto>>;