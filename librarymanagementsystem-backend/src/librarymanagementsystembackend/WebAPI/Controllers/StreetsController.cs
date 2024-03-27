using Application.Features.Streets.Commands.Create;
using Application.Features.Streets.Commands.Delete;
using Application.Features.Streets.Commands.Update;
using Application.Features.Streets.Queries.GetById;
using Application.Features.Streets.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StreetsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStreetCommand createStreetCommand)
    {
        CreatedStreetResponse response = await Mediator.Send(createStreetCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStreetCommand updateStreetCommand)
    {
        UpdatedStreetResponse response = await Mediator.Send(updateStreetCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStreetResponse response = await Mediator.Send(new DeleteStreetCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStreetResponse response = await Mediator.Send(new GetByIdStreetQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStreetQuery getListStreetQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStreetListItemDto> response = await Mediator.Send(getListStreetQuery);
        return Ok(response);
    }
}