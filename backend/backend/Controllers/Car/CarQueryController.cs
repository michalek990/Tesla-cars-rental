using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using backend.Service.Car.Queries.GetCarsByRentalPoint;
using backend.Service.Car.Queries.GetlAllCars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Car;

[ApiController]
[Route("api/cars")]
public sealed class CarQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("all-cars")]
    public async Task<ActionResult<Page<GetAllCarsDto>>> GetAllAsync([FromQuery] PageRequestDto pageRequestDto)
    {
        var result = await _mediator.Send(new GetAllCarsQuery(pageRequestDto));
        return Ok(result);
    }
    
    [HttpGet("rental-point-cars/")]
    public async Task<ActionResult<Page<GetAllCarsDto>>> GetCarsFromRentalPoint([FromQuery] string rentalPointName, [FromQuery] PageRequestDto pageRequestDto)
    {
        var result = await _mediator.Send(new GetCarsByRentalPointQuery(rentalPointName, pageRequestDto));
        return Ok(result);
    }

}