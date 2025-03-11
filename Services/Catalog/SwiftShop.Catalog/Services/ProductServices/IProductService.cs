using SwiftShop.Catalog.Dtos.CategoryDtos;
using SwiftShop.Catalog.Dtos.ProductDtos;

namespace SwiftShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string productId);
        Task<ResultProductDto> GetProductByIdAsync(string productId);
    }
}
