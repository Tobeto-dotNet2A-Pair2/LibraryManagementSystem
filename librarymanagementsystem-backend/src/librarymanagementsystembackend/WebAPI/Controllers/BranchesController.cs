using Application.Features.Branches.Commands.Create;
using Application.Features.Branches.Commands.Delete;
using Application.Features.Branches.Commands.Update;
using Application.Features.Branches.Queries.GetById;
using Application.Features.Branches.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBranchCommand createBranchCommand)
    {
        CreatedBranchResponse response = await Mediator.Send(createBranchCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBranchCommand updateBranchCommand)
    {
        UpdatedBranchResponse response = await Mediator.Send(updateBranchCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBranchResponse response = await Mediator.Send(new DeleteBranchCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBranchResponse response = await Mediator.Send(new GetByIdBranchQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBranchQuery getListBranchQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBranchListItemDto> response = await Mediator.Send(getListBranchQuery);
        return Ok(response);
    }
}