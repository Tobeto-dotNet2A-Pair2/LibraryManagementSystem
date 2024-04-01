using Application.Features.FavoriteLists.Commands.Create;
using Application.Features.FavoriteLists.Commands.Delete;
using Application.Features.FavoriteLists.Commands.Update;
using Application.Features.FavoriteLists.Queries.GetById;
using Application.Features.FavoriteLists.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoriteListsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFavoriteListCommand createFavoriteListCommand)
    {
        CreatedFavoriteListResponse response = await Mediator.Send(createFavoriteListCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFavoriteListCommand updateFavoriteListCommand)
    {
        UpdatedFavoriteListResponse response = await Mediator.Send(updateFavoriteListCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedFavoriteListResponse response = await Mediator.Send(new DeleteFavoriteListCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdFavoriteListResponse response = await Mediator.Send(new GetByIdFavoriteListQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFavoriteListQuery getListFavoriteListQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFavoriteListListItemDto> response = await Mediator.Send(getListFavoriteListQuery);
        return Ok(response);
    }
}