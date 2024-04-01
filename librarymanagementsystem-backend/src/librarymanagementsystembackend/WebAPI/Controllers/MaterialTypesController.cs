using Application.Features.MaterialTypes.Commands.Create;
using Application.Features.MaterialTypes.Commands.Delete;
using Application.Features.MaterialTypes.Commands.Update;
using Application.Features.MaterialTypes.Queries.GetById;
using Application.Features.MaterialTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialTypeCommand createMaterialTypeCommand)
    {
        CreatedMaterialTypeResponse response = await Mediator.Send(createMaterialTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialTypeCommand updateMaterialTypeCommand)
    {
        UpdatedMaterialTypeResponse response = await Mediator.Send(updateMaterialTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialTypeResponse response = await Mediator.Send(new DeleteMaterialTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialTypeResponse response = await Mediator.Send(new GetByIdMaterialTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialTypeQuery getListMaterialTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialTypeListItemDto> response = await Mediator.Send(getListMaterialTypeQuery);
        return Ok(response);
    }
}