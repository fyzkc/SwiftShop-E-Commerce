using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.Dto.Dtos.Shipment;

namespace SwiftShop.Shipping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [Authorize(Policy = "ShippingReadOrFullPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllShipments()
        {
            var allShipments = await _shipmentService.GetAll();
            return Ok(allShipments);
        }

        [Authorize(Policy = "ShippingReadOrFullPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentById(int id)
        {
            var shipment = await _shipmentService.GetById(id);
            return Ok(shipment);
        }

        [Authorize(Policy = "ShippingFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateShipment(CreateShipmentDto createShipmentDto)
        {
            await _shipmentService.Create(createShipmentDto);
            return Ok("Shipment created successfully!");
        }

        [Authorize(Policy = "ShippingFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateShipment(UpdateShipmentDto updateShipmentDto)
        {
            await _shipmentService.Update(updateShipmentDto);
            return Ok("Shipment updated successfully!");
        }

        [Authorize(Policy = "ShippingFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            await _shipmentService.Delete(id);
            return Ok("Shipment deleted successfully!");
        }
    }
}
