using Application.Features.PublisherMaterials.Commands.Create;
using Application.Features.PublisherMaterials.Commands.Delete;
using Application.Features.PublisherMaterials.Commands.Update;
using Application.Features.PublisherMaterials.Queries.GetById;
using Application.Features.PublisherMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePublisherMaterialCommand createPublisherMaterialCommand)
    {
        CreatedPublisherMaterialResponse response = await Mediator.Send(createPublisherMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePublisherMaterialCommand updatePublisherMaterialCommand)
    {
        UpdatedPublisherMaterialResponse response = await Mediator.Send(updatePublisherMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPublisherMaterialResponse response = await Mediator.Send(new DeletePublisherMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPublisherMaterialResponse response = await Mediator.Send(new GetByIdPublisherMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPublisherMaterialQuery getListPublisherMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPublisherMaterialListItemDto> response = await Mediator.Send(getListPublisherMaterialQuery);
        return Ok(response);
    }
}