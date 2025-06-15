using AutoMapper;
using MongoDB.Driver;
using SwiftShop.Catalog.Dtos.BrandCampaignDtos;
using SwiftShop.Catalog.Entities;
using SwiftShop.Catalog.Settings;

namespace SwiftShop.Catalog.Services.BrandCampaignServices
{
    public class BrandCampaignService : IBrandCampaignService
    {
        private readonly IMongoCollection<BrandCampaign> _brandCampaignCollection;
        private readonly IMapper _mapper;

        public BrandCampaignService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _brandCampaignCollection = database.GetCollection<BrandCampaign>(databaseSettings.BrandCampaignCollectionName);
            _mapper = mapper;
        }

        public async Task ChangeStatusAsync(string brandCampaignId, bool newStatus)
        {
            var updateDefinition = Builders<BrandCampaign>.Update.Set(b => b.Status, newStatus);

            var result = await _brandCampaignCollection.UpdateOneAsync(
                s => s.BrandCampaignId == brandCampaignId,
                updateDefinition
            );

            if (result.MatchedCount == 0)
            {
                throw new Exception("Belirtilen ID'ye sahip Brand Campaign bulunamadı.");
            }
        }

        public async Task CreateBrandCampaignAsync(CreateBrandCampaignDto createBrandCampaignDto)
        {
            var insertingValue = _mapper.Map<BrandCampaign>(createBrandCampaignDto);
            await _brandCampaignCollection.InsertOneAsync(insertingValue);
        }

        public async Task DeleteBrandCampaignAsync(string brandCampaignId)
        {
            await _brandCampaignCollection.DeleteOneAsync(b => b.BrandCampaignId == brandCampaignId);
        }

        public async Task<List<ResultBrandCampaignDto>> GetAllBrandCampaignAsync()
        {
            var allBrandCampaigns = await _brandCampaignCollection.Find(b => true).ToListAsync();
            return _mapper.Map<List<ResultBrandCampaignDto>>(allBrandCampaigns);
        }

        public async Task<ResultBrandCampaignDto> GetBrandCampaignByIdAsync(string brandCampaignId)
        {
            var brandCampaign = await _brandCampaignCollection.Find(b => b.BrandCampaignId == brandCampaignId).FirstOrDefaultAsync();
            return _mapper.Map<ResultBrandCampaignDto>(brandCampaign);
        }

        public async Task UpdateBrandCampaignAsync(UpdateBrandCampaignDto updateBrandCampaignDto)
        {
            var updatingValue = _mapper.Map<BrandCampaign>(updateBrandCampaignDto);
            await _brandCampaignCollection.FindOneAndReplaceAsync(b => b.BrandCampaignId == updateBrandCampaignDto.BrandCampaignId, updatingValue);
        }
    }
}
