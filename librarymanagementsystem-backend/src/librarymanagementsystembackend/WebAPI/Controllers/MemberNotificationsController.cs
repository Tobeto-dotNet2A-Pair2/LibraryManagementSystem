using Application.Features.MemberNotifications.Commands.Create;
using Application.Features.MemberNotifications.Commands.Delete;
using Application.Features.MemberNotifications.Commands.Update;
using Application.Features.MemberNotifications.Queries.GetById;
using Application.Features.MemberNotifications.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberNotificationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMemberNotificationCommand createMemberNotificationCommand)
    {
        CreatedMemberNotificationResponse response = await Mediator.Send(createMemberNotificationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMemberNotificationCommand updateMemberNotificationCommand)
    {
        UpdatedMemberNotificationResponse response = await Mediator.Send(updateMemberNotificationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMemberNotificationResponse response = await Mediator.Send(new DeleteMemberNotificationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMemberNotificationResponse response = await Mediator.Send(new GetByIdMemberNotificationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMemberNotificationQuery getListMemberNotificationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMemberNotificationListItemDto> response = await Mediator.Send(getListMemberNotificationQuery);
        return Ok(response);
    }
}