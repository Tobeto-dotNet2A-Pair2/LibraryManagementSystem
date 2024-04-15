using Application.Features.LanguageMaterials.Commands.Create;
using Application.Features.LanguageMaterials.Commands.Delete;
using Application.Features.LanguageMaterials.Commands.Update;
using Application.Features.LanguageMaterials.Queries.GetById;
using Application.Features.LanguageMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLanguageMaterialCommand createLanguageMaterialCommand)
    {
        CreatedLanguageMaterialResponse response = await Mediator.Send(createLanguageMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLanguageMaterialCommand updateLanguageMaterialCommand)
    {
        UpdatedLanguageMaterialResponse response = await Mediator.Send(updateLanguageMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedLanguageMaterialResponse response = await Mediator.Send(new DeleteLanguageMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdLanguageMaterialResponse response = await Mediator.Send(new GetByIdLanguageMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageMaterialQuery getListLanguageMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLanguageMaterialListItemDto> response = await Mediator.Send(getListLanguageMaterialQuery);
        return Ok(response);
    }
}