using SwiftShop.Catalog.Dtos.ProductDetailDtos;
using SwiftShop.Catalog.Dtos.ProductDtos;

namespace SwiftShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string productDetailId);
        Task<ResultProductDetailDto> GetProductDetailByIdAsync(string productDetailId);
    }
}
