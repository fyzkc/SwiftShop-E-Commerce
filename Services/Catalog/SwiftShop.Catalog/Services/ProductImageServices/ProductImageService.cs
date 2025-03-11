using AutoMapper;
using MongoDB.Driver;
using SwiftShop.Catalog.Dtos.ProductDetailDtos;
using SwiftShop.Catalog.Dtos.ProductImageDtos;
using SwiftShop.Catalog.Entities;
using SwiftShop.Catalog.Settings;

namespace SwiftShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var insertingValue = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(insertingValue);
        }

        public async Task DeleteProductImageAsync(string productImageId)
        {
            await _productImageCollection.DeleteOneAsync(pd => pd.ProductImageId == productImageId);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var productImages = await _productImageCollection.Find(pd => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(productImages);
        }

        public async Task<ResultProductImageDto> GetProductImageByIdAsync(string productImageId)
        {
            var productImage = await _productImageCollection.Find(pd => pd.ProductImageId == productImageId).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductImageDto>(productImage);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var updatingValue = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(pd => pd.ProductImageId == updateProductImageDto.ProductImageId, updatingValue);
        }
    }
}
