using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Commands.Delete;
using Application.Features.Notifications.Commands.Update;
using Application.Features.Notifications.Queries.GetById;
using Application.Features.Notifications.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateNotificationCommand createNotificationCommand)
    {
        CreatedNotificationResponse response = await Mediator.Send(createNotificationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateNotificationCommand updateNotificationCommand)
    {
        UpdatedNotificationResponse response = await Mediator.Send(updateNotificationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedNotificationResponse response = await Mediator.Send(new DeleteNotificationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdNotificationResponse response = await Mediator.Send(new GetByIdNotificationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListNotificationQuery getListNotificationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListNotificationListItemDto> response = await Mediator.Send(getListNotificationQuery);
        return Ok(response);
    }
}