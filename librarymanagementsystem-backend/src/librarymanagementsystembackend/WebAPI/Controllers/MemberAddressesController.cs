using Application.Features.MemberAddresses.Commands.Create;
using Application.Features.MemberAddresses.Commands.Delete;
using Application.Features.MemberAddresses.Commands.Update;
using Application.Features.MemberAddresses.Queries.GetById;
using Application.Features.MemberAddresses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberAddressesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMemberAddressCommand createMemberAddressCommand)
    {
        CreatedMemberAddressResponse response = await Mediator.Send(createMemberAddressCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMemberAddressCommand updateMemberAddressCommand)
    {
        UpdatedMemberAddressResponse response = await Mediator.Send(updateMemberAddressCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMemberAddressResponse response = await Mediator.Send(new DeleteMemberAddressCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMemberAddressResponse response = await Mediator.Send(new GetByIdMemberAddressQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMemberAddressQuery getListMemberAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMemberAddressListItemDto> response = await Mediator.Send(getListMemberAddressQuery);
        return Ok(response);
    }
}