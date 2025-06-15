using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Catalog.Dtos.FeatureSliderDtos;
using SwiftShop.Catalog.Services.FeatureSliderServices;
using SwiftShop.Catalog.Services.ProductServices;

namespace SwiftShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;
        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllFeatureSliders()
        {
            var allFeatureSliders = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(allFeatureSliders);
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet("{featureSliderId}")]
        public async Task<IActionResult> GetFeatureSliderById(string featureSliderId)
        {
            var featureSlider = await _featureSliderService.GetFeatureSliderByIdAsync(featureSliderId);
            return Ok(featureSlider);
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Feature Slider added successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Feature Slider updated successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string featureSliderId)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(featureSliderId);
            return Ok("Feature Slider deleted successfully");
        }
    }
}
