using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Shipping.Business.Abstract;
using SwiftShop.Shipping.Dto.Dtos.Carrier;

namespace SwiftShop.Shipping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private readonly ICarrierService _carrierService;

        public CarriersController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarriers()
        {
            var allCarriers = await _carrierService.GetAll();
            return Ok(allCarriers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrierById(int id)
        {
            var carrier = await _carrierService.GetById(id);
            return Ok(carrier);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrier(CreateCarrierDto createCarrierDto)
        {
            await _carrierService.Create(createCarrierDto);
            return Ok("Carrier created successfully!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrier(UpdateCarrierDto updateCarrierDto)
        {
            await _carrierService.Update(updateCarrierDto);
            return Ok("Carrier updated successfully!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarrier(int id)
        {
            await _carrierService.Delete(id);
            return Ok("Carrier deleted successfully!");
        }
    }
}
