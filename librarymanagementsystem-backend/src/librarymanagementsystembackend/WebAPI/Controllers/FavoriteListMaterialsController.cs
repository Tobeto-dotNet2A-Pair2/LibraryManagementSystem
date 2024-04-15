using Application.Features.FavoriteListMaterials.Commands.Create;
using Application.Features.FavoriteListMaterials.Commands.Delete;
using Application.Features.FavoriteListMaterials.Commands.Update;
using Application.Features.FavoriteListMaterials.Queries.GetById;
using Application.Features.FavoriteListMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoriteListMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFavoriteListMaterialCommand createFavoriteListMaterialCommand)
    {
        CreatedFavoriteListMaterialResponse response = await Mediator.Send(createFavoriteListMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFavoriteListMaterialCommand updateFavoriteListMaterialCommand)
    {
        UpdatedFavoriteListMaterialResponse response = await Mediator.Send(updateFavoriteListMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedFavoriteListMaterialResponse response = await Mediator.Send(new DeleteFavoriteListMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdFavoriteListMaterialResponse response = await Mediator.Send(new GetByIdFavoriteListMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFavoriteListMaterialQuery getListFavoriteListMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFavoriteListMaterialListItemDto> response = await Mediator.Send(getListFavoriteListMaterialQuery);
        return Ok(response);
    }
}