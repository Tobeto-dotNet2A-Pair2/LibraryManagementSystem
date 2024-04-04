using Application.Features.Publishers.Commands.Create;
using Application.Features.Publishers.Commands.Delete;
using Application.Features.Publishers.Commands.Update;
using Application.Features.Publishers.Queries.GetById;
using Application.Features.Publishers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePublisherCommand createPublisherCommand)
    {
        CreatedPublisherResponse response = await Mediator.Send(createPublisherCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePublisherCommand updatePublisherCommand)
    {
        UpdatedPublisherResponse response = await Mediator.Send(updatePublisherCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPublisherResponse response = await Mediator.Send(new DeletePublisherCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPublisherResponse response = await Mediator.Send(new GetByIdPublisherQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPublisherQuery getListPublisherQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPublisherListItemDto> response = await Mediator.Send(getListPublisherQuery);
        return Ok(response);
    }
}