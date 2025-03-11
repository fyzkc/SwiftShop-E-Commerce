using SwiftShop.Catalog.Dtos.ProductDetailDtos;
using SwiftShop.Catalog.Dtos.ProductImageDtos;

namespace SwiftShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string productImageId);
        Task<ResultProductImageDto> GetProductImageByIdAsync(string productImageId);
    }
}
