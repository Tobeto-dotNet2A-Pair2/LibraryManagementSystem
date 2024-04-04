using Application.Features.Neighborhoods.Commands.Create;
using Application.Features.Neighborhoods.Commands.Delete;
using Application.Features.Neighborhoods.Commands.Update;
using Application.Features.Neighborhoods.Queries.GetById;
using Application.Features.Neighborhoods.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NeighborhoodsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateNeighborhoodCommand createNeighborhoodCommand)
    {
        CreatedNeighborhoodResponse response = await Mediator.Send(createNeighborhoodCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateNeighborhoodCommand updateNeighborhoodCommand)
    {
        UpdatedNeighborhoodResponse response = await Mediator.Send(updateNeighborhoodCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedNeighborhoodResponse response = await Mediator.Send(new DeleteNeighborhoodCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdNeighborhoodResponse response = await Mediator.Send(new GetByIdNeighborhoodQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListNeighborhoodQuery getListNeighborhoodQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListNeighborhoodListItemDto> response = await Mediator.Send(getListNeighborhoodQuery);
        return Ok(response);
    }
}