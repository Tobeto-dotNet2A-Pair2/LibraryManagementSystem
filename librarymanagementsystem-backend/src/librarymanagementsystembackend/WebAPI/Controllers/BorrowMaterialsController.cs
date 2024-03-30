using Application.Features.BorrowMaterials.Commands.Create;
using Application.Features.BorrowMaterials.Commands.Delete;
using Application.Features.BorrowMaterials.Commands.Update;
using Application.Features.BorrowMaterials.Queries.GetById;
using Application.Features.BorrowMaterials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowMaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBorrowMaterialCommand createBorrowMaterialCommand)
    {
        CreatedBorrowMaterialResponse response = await Mediator.Send(createBorrowMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBorrowMaterialCommand updateBorrowMaterialCommand)
    {
        UpdatedBorrowMaterialResponse response = await Mediator.Send(updateBorrowMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBorrowMaterialResponse response = await Mediator.Send(new DeleteBorrowMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBorrowMaterialResponse response = await Mediator.Send(new GetByIdBorrowMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBorrowMaterialQuery getListBorrowMaterialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBorrowMaterialListItemDto> response = await Mediator.Send(getListBorrowMaterialQuery);
        return Ok(response);
    }
}