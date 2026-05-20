using CleanArchitecture.Application.Alquileres.GetAlquiler;
using CleanArchitecture.Application.Alquileres.ReservarAlquiler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Alquileres;

[ApiController]
[Route("api/alquileres")]
public class AlquileresController : ControllerBase
{
    private readonly ISender _sender;

    public AlquileresController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlquiler(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetAlquilerQuery(id);
        var resultado = await _sender.Send(query, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReservaAlquiler(
        AlquilerReservaRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new ReservarAlquilerCommand(
            request.VehiculoId,
            request.UserId,
            request.StartDate,
            request.EndDate
        );

        var resultado = await _sender.Send(command, cancellationToken);

        if (resultado.IsFailure)
        {
            return BadRequest(resultado.Error);
        }

        return CreatedAtAction(nameof(GetAlquiler), new { id = resultado.Value }, resultado.Value);
    }
}
