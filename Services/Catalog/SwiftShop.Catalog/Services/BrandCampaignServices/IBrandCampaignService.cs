using SwiftShop.Catalog.Dtos.BrandCampaignDtos;

namespace SwiftShop.Catalog.Services.BrandCampaignServices
{
    public interface IBrandCampaignService
    {
        Task<List<ResultBrandCampaignDto>> GetAllBrandCampaignAsync();
        Task CreateBrandCampaignAsync(CreateBrandCampaignDto createBrandCampaignDto);
        Task UpdateBrandCampaignAsync(UpdateBrandCampaignDto updateBrandCampaignDto);
        Task DeleteBrandCampaignAsync(string brandCampaignId);
        Task<ResultBrandCampaignDto> GetBrandCampaignByIdAsync(string brandCampaignId);
        Task ChangeStatusAsync(string brandCampaignId, bool newStatus);
    }
}
