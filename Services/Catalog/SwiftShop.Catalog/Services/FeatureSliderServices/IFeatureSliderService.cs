using SwiftShop.Catalog.Dtos.FeatureSliderDtos;

namespace SwiftShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string featureSliderId);
        Task<ResultFeatureSliderDto> GetFeatureSliderByIdAsync(string featureSliderId);
        Task ChangeStatusAsync(string featureSliderId, bool newStatus);
    }
}
