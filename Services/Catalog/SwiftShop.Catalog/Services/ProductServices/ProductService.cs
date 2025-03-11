using AutoMapper;
using MongoDB.Driver;
using SwiftShop.Catalog.Dtos.ProductDtos;
using SwiftShop.Catalog.Entities;
using SwiftShop.Catalog.Settings;

namespace SwiftShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var insertingValue = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(insertingValue);
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _productCollection.DeleteOneAsync(p => p.ProductId == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var allProducts = await _productCollection.Find(p => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(allProducts);
        }

        public async Task<ResultProductDto> GetProductByIdAsync(string productId)
        {
            var product = await _productCollection.Find(p => p.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDto>(product);

        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var updatingValue = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(p => p.ProductId == updateProductDto.ProductId, updatingValue);
        }
    }
}
