using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.CategoryDtos;
using SwiftShop.UIDtoLayer.CatalogDtos.ProductDtos;
using SwiftShop.WebUI.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SwiftShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Ürünleri al
            var productResponse = await client.GetAsync("https://localhost:7100/api/Products");
            if (!productResponse.IsSuccessStatusCode)
                return BadRequest("Ürünler alınamadı.");

            var productJson = await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productJson);

            // Kategorileri al
            var categoryResponse = await client.GetAsync("https://localhost:7100/api/Categories");
            if (!categoryResponse.IsSuccessStatusCode)
                return BadRequest("Kategoriler alınamadı.");

            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            // Eşleştir
            var viewModel = products.Select(p => new ProductWithCategoryViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                ProductImageUrl = p.ProductImageUrl,
                ProductDescription = p.ProductDescription,
                CategoryId = p.CategoryId,
                CategoryName = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)?.CategoryName
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var selectCategory = await client.GetAsync("https://localhost:7100/api/Categories");
            var jsonCategories = await selectCategory.Content.ReadAsStringAsync();
            var stringCategories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategories);
            List<SelectListItem> categoryValues = (from x in stringCategories
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7100/api/Products", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("Ürün eklenemedi.");
            }

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/Products?productId={id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("Silme işlemi başarısız oldu.");
            }

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Ürünü getir
            var response = await client.GetAsync($"https://localhost:7100/api/Products/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

            // Kategori listesi
            var categoryResponse = await client.GetAsync("https://localhost:7100/api/Categories");
            var jsonCategories = await categoryResponse.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategories);

            ViewBag.Categories = categoryList
                .Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId,
                    Selected = (c.CategoryId == product.CategoryId)
                }).ToList();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5Mzk0OTcsImV4cCI6MTc0OTk0MTI5NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxMjI2ODI0NDBGODQ4QTUwRDNEMzlFREU3MUMyNjM0IiwiaWF0IjoxNzQ5OTM5NDk3LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.pwpOtlK234CVr90piuQLLcFScf8FPYaD68tcQZNi_5N5TbfemOERg2l-NDivV2H7e97GqE08bUYM2cjLf7IyuQqk2xNgFk3aRGyQWBF5sahHvMoCfeH_q6WsckNdazzrdG9392NrDO6r_TUFYwKQkXxRjO9nlQUgXe-7NzSbfPm51G_38J9EePFIFIXMfkHt7aVAhtFGehdzOpzV46MlymPnuq0ZKBbfSnkSSz019XRs81IxqX4ccLJVwVi2L7cm5IUVn5keif8pzsjIDYbDA-R6TRkaDn7SrBLDmUKzdbQKL0cnMpsLcxplXJo-hCea04qrHJKNJYCAFHdW7sMzFg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7100/api/Products", content);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Güncelleme başarısız.");

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
