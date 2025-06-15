using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.CategoryDtos;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class CategoriesComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoriesComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Categories");


            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoriesAsString = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            return View(categoriesAsString);
        }
    }
}
