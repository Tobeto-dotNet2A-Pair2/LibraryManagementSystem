using Application.Features.PaymentMethods.Commands.Create;
using Application.Features.PaymentMethods.Commands.Delete;
using Application.Features.PaymentMethods.Commands.Update;
using Application.Features.PaymentMethods.Queries.GetById;
using Application.Features.PaymentMethods.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentMethodsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePaymentMethodCommand createPaymentMethodCommand)
    {
        CreatedPaymentMethodResponse response = await Mediator.Send(createPaymentMethodCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePaymentMethodCommand updatePaymentMethodCommand)
    {
        UpdatedPaymentMethodResponse response = await Mediator.Send(updatePaymentMethodCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedPaymentMethodResponse response = await Mediator.Send(new DeletePaymentMethodCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdPaymentMethodResponse response = await Mediator.Send(new GetByIdPaymentMethodQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPaymentMethodQuery getListPaymentMethodQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPaymentMethodListItemDto> response = await Mediator.Send(getListPaymentMethodQuery);
        return Ok(response);
    }
}