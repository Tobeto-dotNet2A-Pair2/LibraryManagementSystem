using Application.Features.Libraries.Commands.Create;
using Application.Features.Libraries.Commands.Delete;
using Application.Features.Libraries.Commands.Update;
using Application.Features.Libraries.Queries.GetById;
using Application.Features.Libraries.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibrariesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLibraryCommand createLibraryCommand)
    {
        CreatedLibraryResponse response = await Mediator.Send(createLibraryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLibraryCommand updateLibraryCommand)
    {
        UpdatedLibraryResponse response = await Mediator.Send(updateLibraryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedLibraryResponse response = await Mediator.Send(new DeleteLibraryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdLibraryResponse response = await Mediator.Send(new GetByIdLibraryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLibraryQuery getListLibraryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLibraryListItemDto> response = await Mediator.Send(getListLibraryQuery);
        return Ok(response);
    }
}