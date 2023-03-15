using backend.Models;
using backend.Service.Rental.Commands.CreateRental;
using backend.Service.Rental.Commands.DeleteRental;
using backend.Service.Rental.Commands.UpdateRental;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Rental;

[ApiController]
[Route("api/rentals")]
public sealed class RentalCommandController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentalCommandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateRentalDto>> CreateNewRental([FromBody] CreateRentalCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"api/rentals/{result.FirstName}-{result.Surname}", result);
    }

    [HttpPut("{peselNumber},{model},{endRentalPoint}")]
    public async Task<ActionResult<UpdateRentalDto>> UpdateRental([FromRoute] string peselNumber, [FromRoute] string model, [FromRoute] string endRentalPoint, [FromBody] UpdateRentalDto dto)
    {
        var result = await _mediator.Send(new UpdateRentalCommand(peselNumber, model, endRentalPoint, dto));
        return Ok(result);
    }

    [HttpDelete("{peselNumber},{model},{endRentalPoint}")]
    public async Task<IActionResult> DeleteRental([FromRoute] string peselNumber, [FromRoute] string model, [FromRoute] string endRentalPoint)
    {
        await _mediator.Send(new DeleteRentalCommand(peselNumber, model, endRentalPoint));
        return NoContent();
    }
}