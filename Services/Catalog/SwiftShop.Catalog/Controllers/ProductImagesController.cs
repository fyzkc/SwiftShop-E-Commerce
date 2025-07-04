﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Catalog.Dtos.ProductImageDtos;
using SwiftShop.Catalog.Services.ProductImageServices;

namespace SwiftShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllProductImages()
        {
            var productImages = await _productImageService.GetAllProductImagesAsync();
            return Ok(productImages);
        }

        //[Authorize(Policy = "CatalogReadOrFullPolicy")]
        [AllowAnonymous]
        [HttpGet("{productImageId}")]
        public async Task<IActionResult> GetProductImageById(string productImageId)
        {
            var productImage = await _productImageService.GetProductImageByIdAsync(productImageId);
            return Ok(productImage);
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Product image created successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Product image updated successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string productImageId)
        {
            await _productImageService.DeleteProductImageAsync(productImageId);
            return Ok("Product image deleted successfully");
        }
    }
}
