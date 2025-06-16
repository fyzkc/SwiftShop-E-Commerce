using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.CategoryDtos;
using SwiftShop.UIDtoLayer.CatalogDtos.ProductDtos;
using SwiftShop.WebUI.Areas.Admin.Models;

namespace SwiftShop.WebUI.Controllers
{
    public class ProductsListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string? categoryId)
        {
            var client = _httpClientFactory.CreateClient();

            // Ürünleri çek
            var productResponse = await client.GetAsync("https://localhost:7100/api/Products");
            if (!productResponse.IsSuccessStatusCode)
                return BadRequest("Ürünler alınamadı.");

            var productJson = await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productJson);

            // Kategorileri çek
            var categoryResponse = await client.GetAsync("https://localhost:7100/api/Categories");
            if (!categoryResponse.IsSuccessStatusCode)
                return BadRequest("Kategoriler alınamadı.");

            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            // Eşleştir ve filtrele
            var viewModel = products
                .Where(p => string.IsNullOrEmpty(categoryId) || p.CategoryId == categoryId)
                .Select(p => new ProductWithCategoryViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductPrice = p.ProductPrice,
                    ProductImageUrl = p.ProductImageUrl,
                    ProductDescription = p.ProductDescription,
                    CategoryId = p.CategoryId,
                    CategoryName = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)?.CategoryName
                }).ToList();

            // Seçilen kategori ID’yi View’a taşı
            ViewBag.SelectedCategoryId = categoryId;

            return View(viewModel);
        }
    }
}
