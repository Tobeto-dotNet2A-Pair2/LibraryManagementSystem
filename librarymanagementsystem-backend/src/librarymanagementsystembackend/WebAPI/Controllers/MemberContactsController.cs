using Application.Features.MemberContacts.Commands.Create;
using Application.Features.MemberContacts.Commands.Delete;
using Application.Features.MemberContacts.Commands.Update;
using Application.Features.MemberContacts.Queries.GetById;
using Application.Features.MemberContacts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberContactsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMemberContactCommand createMemberContactCommand)
    {
        CreatedMemberContactResponse response = await Mediator.Send(createMemberContactCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMemberContactCommand updateMemberContactCommand)
    {
        UpdatedMemberContactResponse response = await Mediator.Send(updateMemberContactCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMemberContactResponse response = await Mediator.Send(new DeleteMemberContactCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMemberContactResponse response = await Mediator.Send(new GetByIdMemberContactQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMemberContactQuery getListMemberContactQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMemberContactListItemDto> response = await Mediator.Send(getListMemberContactQuery);
        return Ok(response);
    }
}