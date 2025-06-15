using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Catalog.Dtos.BrandCampaignDtos;
using SwiftShop.Catalog.Services.BrandCampaignServices;
using SwiftShop.Catalog.Services.SpecialOfferServices;

namespace SwiftShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandCampaignsController : ControllerBase
    {
        private readonly IBrandCampaignService _brandCampaignService;

        public BrandCampaignsController(IBrandCampaignService brandCampaignService)
        {
            _brandCampaignService = brandCampaignService;
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllBrandCampaigns()
        {
            var allBrandCampaigns = await _brandCampaignService.GetAllBrandCampaignAsync();
            return Ok(allBrandCampaigns);
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet("{brandCampaignId}")]
        public async Task<IActionResult> GetBrandCampaignById(string brandCampaignId)
        {
            var brandCampaign = await _brandCampaignService.GetBrandCampaignByIdAsync(brandCampaignId);
            return Ok(brandCampaign);
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateBrandCampaign(CreateBrandCampaignDto createBrandCampaignDto)
        {
            await _brandCampaignService.CreateBrandCampaignAsync(createBrandCampaignDto);
            return Ok("Brand Campaign added successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateBrandCampaign(UpdateBrandCampaignDto updateBrandCampaignDto)
        {
            await _brandCampaignService.UpdateBrandCampaignAsync(updateBrandCampaignDto);
            return Ok("Brand Campaign updated successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBrandCampaign(string brandCampaignId)
        {
            await _brandCampaignService.DeleteBrandCampaignAsync(brandCampaignId);
            return Ok("Brand Campaign deleted successfully");
        }
    }
}
