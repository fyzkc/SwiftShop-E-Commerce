using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.BrandCampaignDtos;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class BrandsComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7100/api/BrandCampaigns");


            var jsonData = await response.Content.ReadAsStringAsync();
            var allOffers = JsonConvert.DeserializeObject<List<ResultBrandCampaignDto>>(jsonData);

            var selectedOffers = allOffers
                .Where(x => x.Status == true)
                .Take(10)
                .ToList();

            return View(selectedOffers);
        }
    }
}
