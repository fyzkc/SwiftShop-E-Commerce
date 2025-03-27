using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Order.Application.Features.Commands.OrderDetailCommands;
using SwiftShop.Order.Application.Features.Queries.OrderDetailQueries;

namespace SwiftShop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var orderDetails = await _mediator.Send(new GetOrderDetailQuery());
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var orderDetail = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _mediator.Send(createOrderDetailCommand);
            return Ok("Order detail created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _mediator.Send(updateOrderDetailCommand);
            return Ok("Order detail updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _mediator.Send(new RemoveOrderDetailCommand(id));
            return Ok("Order detail deleted successfully");
        }
    }
}
