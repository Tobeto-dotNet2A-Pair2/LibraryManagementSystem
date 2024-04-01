using Application.Features.MaterialPropertyValues.Commands.Create;
using Application.Features.MaterialPropertyValues.Commands.Delete;
using Application.Features.MaterialPropertyValues.Commands.Update;
using Application.Features.MaterialPropertyValues.Queries.GetById;
using Application.Features.MaterialPropertyValues.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialPropertyValuesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialPropertyValueCommand createMaterialPropertyValueCommand)
    {
        CreatedMaterialPropertyValueResponse response = await Mediator.Send(createMaterialPropertyValueCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialPropertyValueCommand updateMaterialPropertyValueCommand)
    {
        UpdatedMaterialPropertyValueResponse response = await Mediator.Send(updateMaterialPropertyValueCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialPropertyValueResponse response = await Mediator.Send(new DeleteMaterialPropertyValueCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialPropertyValueResponse response = await Mediator.Send(new GetByIdMaterialPropertyValueQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialPropertyValueQuery getListMaterialPropertyValueQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialPropertyValueListItemDto> response = await Mediator.Send(getListMaterialPropertyValueQuery);
        return Ok(response);
    }
}