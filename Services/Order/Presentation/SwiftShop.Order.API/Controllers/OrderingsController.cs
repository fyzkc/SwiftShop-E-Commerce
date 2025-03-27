using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Order.Application.Features.Commands.OrderingCommands;
using SwiftShop.Order.Application.Features.Queries.OrderingQueries;

namespace SwiftShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderings()
        {
            var orderings = await _mediator.Send(new GetOrderingQuery());
            return Ok(orderings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var ordering = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(ordering);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);
            return Ok("Order is created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok("Order is updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Order deleted successfully");
        }
    }
}
