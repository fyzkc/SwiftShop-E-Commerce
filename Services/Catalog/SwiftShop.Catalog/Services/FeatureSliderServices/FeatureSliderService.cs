using AutoMapper;
using MongoDB.Driver;
using SwiftShop.Catalog.Dtos.FeatureSliderDtos;
using SwiftShop.Catalog.Entities;
using SwiftShop.Catalog.Settings;

namespace SwiftShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;
        
        public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public FeatureSliderService(IMongoCollection<FeatureSlider> featureSliderCollection, IMapper mapper)
        {
            _featureSliderCollection = featureSliderCollection;
            _mapper = mapper;
        }

        public async Task ChangeStatusAsync(string featureSliderId, bool newStatus)
        {
            var updateDefinition = Builders<FeatureSlider>.Update.Set(f => f.Status, newStatus);

            var result = await _featureSliderCollection.UpdateOneAsync(
                f => f.FeatureSliderId == featureSliderId,
                updateDefinition
            );

            if (result.MatchedCount == 0)
            {
                throw new Exception("Belirtilen ID'ye sahip FeatureSlider bulunamadı.");
            }
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var insertingValue = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(insertingValue);
        }

        public async Task DeleteFeatureSliderAsync(string featureSliderId)
        {
            await _featureSliderCollection.DeleteOneAsync(f => f.FeatureSliderId == featureSliderId);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var allFeatureSlider = await _featureSliderCollection.Find(f => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(allFeatureSlider);
        }

        public async Task<ResultFeatureSliderDto> GetFeatureSliderByIdAsync(string featureSliderId)
        {
            var featureSlider = await _featureSliderCollection.Find(f => f.FeatureSliderId == featureSliderId).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureSliderDto>(featureSlider);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var updatingValue = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(f => f.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, updatingValue);
        }
    }
}
