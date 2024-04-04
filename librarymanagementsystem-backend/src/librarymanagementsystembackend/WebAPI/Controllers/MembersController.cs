using Application.Features.Members.Commands.Create;
using Application.Features.Members.Commands.Delete;
using Application.Features.Members.Commands.Update;
using Application.Features.Members.Queries.GetById;
using Application.Features.Members.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMemberCommand createMemberCommand)
    {
        CreatedMemberResponse response = await Mediator.Send(createMemberCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMemberCommand updateMemberCommand)
    {
        UpdatedMemberResponse response = await Mediator.Send(updateMemberCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMemberResponse response = await Mediator.Send(new DeleteMemberCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMemberResponse response = await Mediator.Send(new GetByIdMemberQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMemberQuery getListMemberQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMemberListItemDto> response = await Mediator.Send(getListMemberQuery);
        return Ok(response);
    }
}