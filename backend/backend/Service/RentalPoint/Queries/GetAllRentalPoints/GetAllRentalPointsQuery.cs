using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using MediatR;

namespace backend.Service.RentalPoint.Queries.GetAllRentalPoints;

public sealed record GetAllRentalPointsQuery(PageRequestDto PageRequestDto) : IRequest<Page<GetAllRentalPointsDto>>;