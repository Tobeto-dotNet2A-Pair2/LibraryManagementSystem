using Application.Features.Translators.Commands.Create;
using Application.Features.Translators.Commands.Delete;
using Application.Features.Translators.Commands.Update;
using Application.Features.Translators.Queries.GetById;
using Application.Features.Translators.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TranslatorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTranslatorCommand createTranslatorCommand)
    {
        CreatedTranslatorResponse response = await Mediator.Send(createTranslatorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTranslatorCommand updateTranslatorCommand)
    {
        UpdatedTranslatorResponse response = await Mediator.Send(updateTranslatorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTranslatorResponse response = await Mediator.Send(new DeleteTranslatorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTranslatorResponse response = await Mediator.Send(new GetByIdTranslatorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTranslatorQuery getListTranslatorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTranslatorListItemDto> response = await Mediator.Send(getListTranslatorQuery);
        return Ok(response);
    }
}