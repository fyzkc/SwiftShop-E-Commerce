using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Catalog.Dtos.SpecialOfferDtos;
using SwiftShop.Catalog.Services.FeatureSliderServices;
using SwiftShop.Catalog.Services.SpecialOfferServices;

namespace SwiftShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllSpecialOffers()
        {
            var allSpecialOffers = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(allSpecialOffers);
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet("{specialOfferId}")]
        public async Task<IActionResult> GetSpecialOfferById(string specialOfferId)
        {
            var specialOffer = await _specialOfferService.GetSpecialOfferByIdAsync(specialOfferId);
            return Ok(specialOffer);
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Special Offer added successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Special Offer updated successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string specialOfferId)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(specialOfferId);
            return Ok("Special Offer deleted successfully");
        }
    }
}
