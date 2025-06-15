using SwiftShop.Catalog.Dtos.FeatureSliderDtos;
using SwiftShop.Catalog.Dtos.SpecialOfferDtos;

namespace SwiftShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string specialOfferId);
        Task<ResultSpecialOfferDto> GetSpecialOfferByIdAsync(string specialOfferId);
        Task ChangeStatusAsync(string specialOfferId, bool newStatus);
    }
}
