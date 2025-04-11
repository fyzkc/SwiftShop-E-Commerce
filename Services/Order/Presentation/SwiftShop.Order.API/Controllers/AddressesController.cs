using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Order.Application.Features.Commands.AddressCommands;
using SwiftShop.Order.Application.Features.Queries.AddressQueries;

namespace SwiftShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "OrderReadOrFullPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _mediator.Send(new GetAddressQuery());
            return Ok(addresses);
        }

        [Authorize(Policy = "OrderReadOrFullPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(address);
        }

        [Authorize(Policy = "OrderFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _mediator.Send(createAddressCommand);
            return Ok("Address created successfully");
        }

        [Authorize(Policy = "OrderFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _mediator.Send(updateAddressCommand);
            return Ok("Address updated successfully");
        }

        [Authorize(Policy = "OrderFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _mediator.Send(new RemoveAddressCommand(id));
            return Ok("Address deleted successfully");
        }
    }
}
