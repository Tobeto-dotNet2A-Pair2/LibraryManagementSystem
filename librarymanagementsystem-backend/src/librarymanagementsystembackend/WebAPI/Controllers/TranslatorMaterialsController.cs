using Application.Features.TranslatorMaterials.Commands.Create;
using Application.Features.TranslatorMaterials.Commands.Delete;
using Application.Features.TranslatorMaterials.Commands.Update;
using Application.Features.TranslatorMaterials.Queries.GetById;
using Application.Features.TranslatorMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TranslatorMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTranslatorMaterialCommand createTranslatorMaterialCommand)
    {
        CreatedTranslatorMaterialResponse response = await Mediator.Send(createTranslatorMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTranslatorMaterialCommand updateTranslatorMaterialCommand)
    {
        UpdatedTranslatorMaterialResponse response = await Mediator.Send(updateTranslatorMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTranslatorMaterialResponse response = await Mediator.Send(new DeleteTranslatorMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTranslatorMaterialResponse response = await Mediator.Send(new GetByIdTranslatorMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTranslatorMaterialQuery getListTranslatorMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTranslatorMaterialListItemDto> response = await Mediator.Send(getListTranslatorMaterialQuery);
        return Ok(response);
    }
}