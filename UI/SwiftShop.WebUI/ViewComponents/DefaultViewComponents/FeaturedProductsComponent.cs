using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.ProductDtos;
using SwiftShop.WebUI.Areas.Admin.Models;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class FeaturedProductsComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeaturedProductsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7100/api/Products");

            var productJson = await responseMessage.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productJson);

            return View(products);
        }
    }
}
