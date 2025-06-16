using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.CategoryDtos;

namespace SwiftShop.WebUI.ViewComponents.ProductsListViewComponents
{
    public class FilterBySizeComponent :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FilterBySizeComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7100/api/Categories");
            if (!response.IsSuccessStatusCode)
                return View(new List<string>());

            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);

            var category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            var categoryName = category?.CategoryName?.Trim().ToLower(); // null kontrolü ve küçük harfe çevirme

            List<string> sizes;

            switch (categoryName)
            {
                case "kıyafet":
                    sizes = new List<string> { "XS", "S", "M", "L", "XL" };
                    break;
                case "ayakkabı":
                    sizes = new List<string> { "36", "37", "38", "39", "40", "41", "42" };
                    break;
                default:
                    sizes = new List<string> { "Standart" };
                    break;
            }

            return View(sizes);
        }
    }
}
