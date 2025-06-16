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

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAxMDI0NzAsImV4cCI6MTc1MDEwNDI3MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjVENDA2NTk5QjVERjUxMzBFMjJFQjg5NTU5OTY5MTc5IiwiaWF0IjoxNzUwMTAyNDcwLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.mgqYkg_23WEcYkxc6FDVeeH50-rc_K5-NJI5Xm0XQi3D2tDsQeymHX2INQTyBtZWl15HkX1ZgSB75DWlWn64J_eg_daI689TaveJOR7KzqNkgo4lLGJiwBOx6X5nD9fmvyHbHWP4L7TD4iLHYz0C_dVF0x0UZcnYkBFPZYuC7vaWwGrpgU293p-dqk7F-4wJoI_5QR3x2KAmoO-tbD9aV3fnbdyjAyf31LZdIzI65JJefLJK1KBH7utvKXQ-G22fWwMi2oqMsNvr4gTRrKuqWIgun_jvvV7qxm13D-1V8wGpPUzwG4FCfPTNls0gky6hMucEQl5mPdswyYYtgkuo3w";

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

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAxMDI0NzAsImV4cCI6MTc1MDEwNDI3MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjVENDA2NTk5QjVERjUxMzBFMjJFQjg5NTU5OTY5MTc5IiwiaWF0IjoxNzUwMTAyNDcwLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.mgqYkg_23WEcYkxc6FDVeeH50-rc_K5-NJI5Xm0XQi3D2tDsQeymHX2INQTyBtZWl15HkX1ZgSB75DWlWn64J_eg_daI689TaveJOR7KzqNkgo4lLGJiwBOx6X5nD9fmvyHbHWP4L7TD4iLHYz0C_dVF0x0UZcnYkBFPZYuC7vaWwGrpgU293p-dqk7F-4wJoI_5QR3x2KAmoO-tbD9aV3fnbdyjAyf31LZdIzI65JJefLJK1KBH7utvKXQ-G22fWwMi2oqMsNvr4gTRrKuqWIgun_jvvV7qxm13D-1V8wGpPUzwG4FCfPTNls0gky6hMucEQl5mPdswyYYtgkuo3w";
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

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAxMDI0NzAsImV4cCI6MTc1MDEwNDI3MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjVENDA2NTk5QjVERjUxMzBFMjJFQjg5NTU5OTY5MTc5IiwiaWF0IjoxNzUwMTAyNDcwLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.mgqYkg_23WEcYkxc6FDVeeH50-rc_K5-NJI5Xm0XQi3D2tDsQeymHX2INQTyBtZWl15HkX1ZgSB75DWlWn64J_eg_daI689TaveJOR7KzqNkgo4lLGJiwBOx6X5nD9fmvyHbHWP4L7TD4iLHYz0C_dVF0x0UZcnYkBFPZYuC7vaWwGrpgU293p-dqk7F-4wJoI_5QR3x2KAmoO-tbD9aV3fnbdyjAyf31LZdIzI65JJefLJK1KBH7utvKXQ-G22fWwMi2oqMsNvr4gTRrKuqWIgun_jvvV7qxm13D-1V8wGpPUzwG4FCfPTNls0gky6hMucEQl5mPdswyYYtgkuo3w";

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

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAxMDI0NzAsImV4cCI6MTc1MDEwNDI3MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjVENDA2NTk5QjVERjUxMzBFMjJFQjg5NTU5OTY5MTc5IiwiaWF0IjoxNzUwMTAyNDcwLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.mgqYkg_23WEcYkxc6FDVeeH50-rc_K5-NJI5Xm0XQi3D2tDsQeymHX2INQTyBtZWl15HkX1ZgSB75DWlWn64J_eg_daI689TaveJOR7KzqNkgo4lLGJiwBOx6X5nD9fmvyHbHWP4L7TD4iLHYz0C_dVF0x0UZcnYkBFPZYuC7vaWwGrpgU293p-dqk7F-4wJoI_5QR3x2KAmoO-tbD9aV3fnbdyjAyf31LZdIzI65JJefLJK1KBH7utvKXQ-G22fWwMi2oqMsNvr4gTRrKuqWIgun_jvvV7qxm13D-1V8wGpPUzwG4FCfPTNls0gky6hMucEQl5mPdswyYYtgkuo3w";
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
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAxMDI0NzAsImV4cCI6MTc1MDEwNDI3MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjVENDA2NTk5QjVERjUxMzBFMjJFQjg5NTU5OTY5MTc5IiwiaWF0IjoxNzUwMTAyNDcwLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.mgqYkg_23WEcYkxc6FDVeeH50-rc_K5-NJI5Xm0XQi3D2tDsQeymHX2INQTyBtZWl15HkX1ZgSB75DWlWn64J_eg_daI689TaveJOR7KzqNkgo4lLGJiwBOx6X5nD9fmvyHbHWP4L7TD4iLHYz0C_dVF0x0UZcnYkBFPZYuC7vaWwGrpgU293p-dqk7F-4wJoI_5QR3x2KAmoO-tbD9aV3fnbdyjAyf31LZdIzI65JJefLJK1KBH7utvKXQ-G22fWwMi2oqMsNvr4gTRrKuqWIgun_jvvV7qxm13D-1V8wGpPUzwG4FCfPTNls0gky6hMucEQl5mPdswyYYtgkuo3w";
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
