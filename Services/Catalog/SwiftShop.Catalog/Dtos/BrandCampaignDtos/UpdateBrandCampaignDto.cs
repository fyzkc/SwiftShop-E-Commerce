namespace SwiftShop.Catalog.Dtos.BrandCampaignDtos
{
    public class UpdateBrandCampaignDto
    {
        public string BrandCampaignId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
