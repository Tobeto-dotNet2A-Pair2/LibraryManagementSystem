using Application.Features.MaterialImages.Commands.Create;
using Application.Features.MaterialImages.Commands.Delete;
using Application.Features.MaterialImages.Commands.Update;
using Application.Features.MaterialImages.Queries.GetById;
using Application.Features.MaterialImages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialImagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialImageCommand createMaterialImageCommand)
    {
        CreatedMaterialImageResponse response = await Mediator.Send(createMaterialImageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialImageCommand updateMaterialImageCommand)
    {
        UpdatedMaterialImageResponse response = await Mediator.Send(updateMaterialImageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialImageResponse response = await Mediator.Send(new DeleteMaterialImageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialImageResponse response = await Mediator.Send(new GetByIdMaterialImageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialImageQuery getListMaterialImageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialImageListItemDto> response = await Mediator.Send(getListMaterialImageQuery);
        return Ok(response);
    }
}