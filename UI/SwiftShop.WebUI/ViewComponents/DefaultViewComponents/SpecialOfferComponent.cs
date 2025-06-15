using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.SpecialOfferDtos;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class SpecialOfferComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7100/api/SpecialOffers");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultSpecialOfferDto>());

            var jsonData = await response.Content.ReadAsStringAsync();
            var allOffers = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);

            var selectedOffers = allOffers
                .Where(x => x.Status == true)
                .Take(2)
                .ToList();

            return View(selectedOffers);
        }
    }
}
