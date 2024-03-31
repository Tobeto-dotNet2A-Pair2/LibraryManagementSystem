using Application.Features.BorrowedMaterials.Commands.Create;
using Application.Features.BorrowedMaterials.Commands.Delete;
using Application.Features.BorrowedMaterials.Commands.Update;
using Application.Features.BorrowedMaterials.Queries.GetById;
using Application.Features.BorrowedMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowedMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBorrowedMaterialCommand createBorrowedMaterialCommand)
    {
        CreatedBorrowedMaterialResponse response = await Mediator.Send(createBorrowedMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBorrowedMaterialCommand updateBorrowedMaterialCommand)
    {
        UpdatedBorrowedMaterialResponse response = await Mediator.Send(updateBorrowedMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBorrowedMaterialResponse response = await Mediator.Send(new DeleteBorrowedMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBorrowedMaterialResponse response = await Mediator.Send(new GetByIdBorrowedMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBorrowedMaterialQuery getListBorrowedMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBorrowedMaterialListItemDto> response = await Mediator.Send(getListBorrowedMaterialQuery);
        return Ok(response);
    }
}