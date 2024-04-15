using Application.Features.AuthorMaterials.Commands.Create;
using Application.Features.AuthorMaterials.Commands.Delete;
using Application.Features.AuthorMaterials.Commands.Update;
using Application.Features.AuthorMaterials.Queries.GetById;
using Application.Features.AuthorMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAuthorMaterialCommand createAuthorMaterialCommand)
    {
        CreatedAuthorMaterialResponse response = await Mediator.Send(createAuthorMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorMaterialCommand updateAuthorMaterialCommand)
    {
        UpdatedAuthorMaterialResponse response = await Mediator.Send(updateAuthorMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAuthorMaterialResponse response = await Mediator.Send(new DeleteAuthorMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAuthorMaterialResponse response = await Mediator.Send(new GetByIdAuthorMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorMaterialQuery getListAuthorMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAuthorMaterialListItemDto> response = await Mediator.Send(getListAuthorMaterialQuery);
        return Ok(response);
    }
}