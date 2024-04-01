using Application.Features.Authors.Commands.Create;
using Application.Features.Authors.Commands.Delete;
using Application.Features.Authors.Commands.Update;
using Application.Features.Authors.Queries.GetById;
using Application.Features.Authors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAuthorCommand createAuthorCommand)
    {
        CreatedAuthorResponse response = await Mediator.Send(createAuthorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand updateAuthorCommand)
    {
        UpdatedAuthorResponse response = await Mediator.Send(updateAuthorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAuthorResponse response = await Mediator.Send(new DeleteAuthorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAuthorResponse response = await Mediator.Send(new GetByIdAuthorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorQuery getListAuthorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAuthorListItemDto> response = await Mediator.Send(getListAuthorQuery);
        return Ok(response);
    }
}