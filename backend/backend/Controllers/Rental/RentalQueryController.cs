using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using backend.Service.Car.Queries.GetlAllCars;
using backend.Service.Rental.Queries.GetlAllRentals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Rental;

[ApiController]
[Route("api/rentals")]
public sealed class RentalQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentalQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("all-rentals")]
    public async Task<ActionResult<Page<GetAllRentalsDto>>> GetAllAsync([FromQuery] PageRequestDto pageRequestDto)
    {
        var result = await _mediator.Send(new GetAllRentalsQuery(pageRequestDto));
        return Ok(result);
    }
}