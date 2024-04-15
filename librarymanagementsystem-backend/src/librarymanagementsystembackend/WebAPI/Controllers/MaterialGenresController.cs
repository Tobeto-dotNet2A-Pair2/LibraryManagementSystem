using Application.Features.MaterialGenres.Commands.Create;
using Application.Features.MaterialGenres.Commands.Delete;
using Application.Features.MaterialGenres.Commands.Update;
using Application.Features.MaterialGenres.Queries.GetById;
using Application.Features.MaterialGenres.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialGenresController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialGenreCommand createMaterialGenreCommand)
    {
        CreatedMaterialGenreResponse response = await Mediator.Send(createMaterialGenreCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialGenreCommand updateMaterialGenreCommand)
    {
        UpdatedMaterialGenreResponse response = await Mediator.Send(updateMaterialGenreCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialGenreResponse response = await Mediator.Send(new DeleteMaterialGenreCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialGenreResponse response = await Mediator.Send(new GetByIdMaterialGenreQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaterialGenreQuery getListMaterialGenreQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaterialGenreListItemDto> response = await Mediator.Send(getListMaterialGenreQuery);
        return Ok(response);
    }
}