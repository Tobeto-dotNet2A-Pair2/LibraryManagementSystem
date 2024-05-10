using Application.Features.MaterialCopies.Commands.Create;
using Application.Features.MaterialCopies.Commands.Delete;
using Application.Features.MaterialCopies.Commands.Update;
using Application.Features.MaterialCopies.Dtos;
using Application.Features.MaterialCopies.Queries.GetById;
using Application.Features.MaterialCopies.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MaterialCopiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialCopyCommand createMaterialCopyCommand)
    {
        CreatedMaterialCopyResponse response = await Mediator.Send(createMaterialCopyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialCopyCommand updateMaterialCopyCommand)
    {
        UpdatedMaterialCopyResponse response = await Mediator.Send(updateMaterialCopyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialCopyResponse response = await Mediator.Send(new DeleteMaterialCopyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialCopyResponse response = await Mediator.Send(new GetByIdMaterialCopyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListMaterialCopyQuery getListMaterialCopyQuery)
    {
        GetListResponse<GetListMaterialCopyDto> response = await Mediator.Send(getListMaterialCopyQuery);
        return Ok(response);
    }
}