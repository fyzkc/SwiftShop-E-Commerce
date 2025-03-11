using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Catalog.Dtos.ProductDetailDtos;
using SwiftShop.Catalog.Services.ProductDetailServices;

namespace SwiftShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var productDetails = await _productDetailService.GetAllProductDetailsAsync();
            return Ok(productDetails);
        }

        [HttpGet("{productDetailId}")]
        public async Task<IActionResult> GetProductDetailById(string productDetailId)
        {
            var productDetail = await _productDetailService.GetProductDetailByIdAsync(productDetailId);
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Product detail created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Product detail updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string productDetailId)
        {
            await _productDetailService.DeleteProductDetailAsync(productDetailId);
            return Ok("Product detail deleted successfully");
        }
    }
}
