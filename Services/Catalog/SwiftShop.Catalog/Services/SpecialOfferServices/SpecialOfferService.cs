using AutoMapper;
using MongoDB.Driver;
using SwiftShop.Catalog.Dtos.SpecialOfferDtos;
using SwiftShop.Catalog.Entities;
using SwiftShop.Catalog.Settings;

namespace SwiftShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;
        private object _featureSliderCollection;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task ChangeStatusAsync(string specialOfferId, bool newStatus)
        {
            var updateDefinition = Builders<SpecialOffer>.Update.Set(s => s.Status, newStatus);

            var result = await _specialOfferCollection.UpdateOneAsync(
                s => s.SpecialOfferId == specialOfferId,
                updateDefinition
            );

            if (result.MatchedCount == 0)
            {
                throw new Exception("Belirtilen ID'ye sahip SpecialOffer bulunamadı.");
            }
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var insertingValue = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(insertingValue);
        }

        public async Task DeleteSpecialOfferAsync(string specialOfferId)
        {
            await _specialOfferCollection.DeleteOneAsync(f => f.SpecialOfferId == specialOfferId);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var allSpecialOffers = await _specialOfferCollection.Find(s => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(allSpecialOffers);
        }

        public async Task<ResultSpecialOfferDto> GetSpecialOfferByIdAsync(string specialOfferId)
        {
            var specialOffer = await _specialOfferCollection.Find(s => s.SpecialOfferId == specialOfferId).FirstOrDefaultAsync();
            return _mapper.Map<ResultSpecialOfferDto>(specialOffer);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var updatingValue = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(s => s.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, updatingValue);
        }
    }
}
