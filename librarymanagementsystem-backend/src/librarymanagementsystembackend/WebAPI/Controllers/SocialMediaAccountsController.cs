using Application.Features.SocialMediaAccounts.Commands.Create;
using Application.Features.SocialMediaAccounts.Commands.Delete;
using Application.Features.SocialMediaAccounts.Commands.Update;
using Application.Features.SocialMediaAccounts.Queries.GetById;
using Application.Features.SocialMediaAccounts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaAccountsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSocialMediaAccountCommand createSocialMediaAccountCommand)
    {
        CreatedSocialMediaAccountResponse response = await Mediator.Send(createSocialMediaAccountCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSocialMediaAccountCommand updateSocialMediaAccountCommand)
    {
        UpdatedSocialMediaAccountResponse response = await Mediator.Send(updateSocialMediaAccountCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSocialMediaAccountResponse response = await Mediator.Send(new DeleteSocialMediaAccountCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSocialMediaAccountResponse response = await Mediator.Send(new GetByIdSocialMediaAccountQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSocialMediaAccountQuery getListSocialMediaAccountQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSocialMediaAccountListItemDto> response = await Mediator.Send(getListSocialMediaAccountQuery);
        return Ok(response);
    }
}