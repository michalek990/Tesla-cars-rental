using AutoMapper;
using backend.Models;
using backend.Models.Pagination;
using backend.Pagination.Response;
using backend.Service.Car.Queries.GetlAllCars;
using backend.Service.RentalPoint.Queries.GetAllRentalPoints;
using backend.Service.RentalPoint.Queries.GetRentalPointByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.RentalPoint;

[ApiController]
[Route("api/rental-points")]
public sealed class RentalPointQueryController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentalPointQueryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<Page<GetAllRentalPointsDto>>> GetAllAsync([FromQuery] PageRequestDto pageRequestDto)
    {
        var result = await _mediator.Send(new GetAllRentalPointsQuery(pageRequestDto));
        return Ok(result);
    }
    
    [HttpGet("by-rental-point-name")]
    public async Task<ActionResult<GetAllRentalPointsDto>> GetByName([FromQuery] string rentalPointName)
    {
        var result = await _mediator.Send(new GetRentalPointByNameQuery(rentalPointName));
        return Ok(result);
    }
}