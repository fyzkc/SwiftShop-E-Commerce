using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.CategoryDtos;

namespace SwiftShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UINavbarComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UINavbarComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7100/api/Categories");
            if (!response.IsSuccessStatusCode)
                return View(new List<ResultCategoryDto>()); // boş liste döner

            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);

            return View(categories);
        }
    }
}
