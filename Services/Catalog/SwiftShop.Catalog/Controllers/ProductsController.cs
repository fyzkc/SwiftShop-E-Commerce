using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Catalog.Dtos.CategoryDtos;
using SwiftShop.Catalog.Dtos.ProductDtos;
using SwiftShop.Catalog.Services.CategoryServices;
using SwiftShop.Catalog.Services.ProductServices;

namespace SwiftShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Policy = "CatalogReadOrFullPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _productService.GetAllProductsAsync();
            return Ok(allProducts);
        }

        [Authorize(Policy = "CatalogReadOrFullPolicy")]
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            return Ok(product);
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Product added successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Product updated successfully");
        }

        [Authorize(Policy = "CatalogFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            await _productService.DeleteProductAsync(productId);
            return Ok("Product deleted successfully");
        }
    }
}
