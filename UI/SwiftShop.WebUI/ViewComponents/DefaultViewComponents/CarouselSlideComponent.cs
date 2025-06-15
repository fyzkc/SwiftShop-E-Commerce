using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.FeatureSliderDtos;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class CarouselSlideComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarouselSlideComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/FeatureSliders");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var featureSlidersAsString = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

            return View(featureSlidersAsString);
        }
    }
}
