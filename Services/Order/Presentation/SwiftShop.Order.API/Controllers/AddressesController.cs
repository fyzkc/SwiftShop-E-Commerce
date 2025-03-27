using MediatR;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _mediator.Send(new GetAddressQuery());
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _mediator.Send(createAddressCommand);
            return Ok("Address created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _mediator.Send(updateAddressCommand);
            return Ok("Address updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _mediator.Send(new RemoveAddressCommand(id));
            return Ok("Address deleted successfully");
        }
    }
}
