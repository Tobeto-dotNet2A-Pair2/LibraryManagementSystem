using Application.Features.Genres.Commands.Create;
using Application.Features.Genres.Commands.Delete;
using Application.Features.Genres.Commands.Update;
using Application.Features.Genres.Queries.GetById;
using Application.Features.Genres.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Languages.Queries.GetList.GetAll;
using Application.Features.Genres.Queries.GetList.GetAll;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGenreCommand createGenreCommand)
    {
        CreatedGenreResponse response = await Mediator.Send(createGenreCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGenreCommand updateGenreCommand)
    {
        UpdatedGenreResponse response = await Mediator.Send(updateGenreCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedGenreResponse response = await Mediator.Send(new DeleteGenreCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdGenreResponse response = await Mediator.Send(new GetByIdGenreQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGenreQuery getListGenreQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGenreListItemDto> response = await Mediator.Send(getListGenreQuery);
        return Ok(response);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllGenresQuery getAllGenresQuery)
    {
        List<GetAllGenresDto> response = await Mediator.Send(getAllGenresQuery);
        return Ok(response);
    }
}