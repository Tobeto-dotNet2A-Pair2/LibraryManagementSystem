using Application.Features.Materials.Commands.Create;
using Application.Features.Materials.Commands.Delete;
using Application.Features.Materials.Commands.Update;
using Application.Features.Materials.Queries.GetById;
using Application.Features.Materials.Queries.GetById.GetDetails;
using Application.Features.Materials.Queries.GetList;
using Application.Features.Materials.Queries.GetList.GetAllForAdmin;
using Application.Features.Materials.Queries.GetList.GetAllForFrontEnd;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Materials.Queries.GetList.GetAll;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MaterialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaterialCommand createMaterialCommand)
    {
        CreatedMaterialResponse response = await Mediator.Send(createMaterialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaterialCommand updateMaterialCommand)
    {
        UpdatedMaterialResponse response = await Mediator.Send(updateMaterialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMaterialResponse response = await Mediator.Send(new DeleteMaterialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMaterialResponse response = await Mediator.Send(new GetByIdMaterialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetAllMaterialsForFrontEndQuery getAllMaterialsForFrontEndQuery)
    {
        GetListResponse<GetAllMaterialsForFrontEndResponse> response = await Mediator.Send(getAllMaterialsForFrontEndQuery);
        return Ok(response);
    }
    //ebruudan gelen---------------------
    [HttpGet]
    public async Task<IActionResult> GetListForAdmin([FromQuery] GetAllMaterialListAdminQuery getAllMaterialListAdminQuery)
    {
        List<GetAllMaterialListAdminDto> response = await Mediator.Send(getAllMaterialListAdminQuery);
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> GetDetailByIdForAdmin([FromQuery] GetDetailByIdForAdminQuery getDetailByIdForAdminQuery)
    {
        GetDetailByIdForAdminDto response = await Mediator.Send(getDetailByIdForAdminQuery);
        return Ok(response);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllMaterialsQuery getAllMaterialsQuery)
    {
        List<GetAllMaterialsDto> response = await Mediator.Send(getAllMaterialsQuery);
        return Ok(response);
    }
}