using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.BrandCampaignDtos;
using System.Net.Http.Headers;
using System.Text;

namespace SwiftShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandCampaignController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandCampaignController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/BrandCampaigns");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var brandCampaignsAsString = JsonConvert.DeserializeObject<List<ResultBrandCampaignDto>>(jsonData);

            return View(brandCampaignsAsString);
        }

        [HttpGet]
        public IActionResult CreateBrandCampaign()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandCampaign(CreateBrandCampaignDto createBrandCampaignDto)
        {
            //its not posting because of authorization
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(createBrandCampaignDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/BrandCampaigns", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            return RedirectToAction("Index", "BrandCampaign", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrandCampaign(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/BrandCampaigns?brandCampaignId={id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("Silme işlemi başarısız oldu.");
            }

            return RedirectToAction("Index", "BrandCampaign", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrandCampaign(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync($"https://localhost:7100/api/BrandCampaigns/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var brandCampaign = JsonConvert.DeserializeObject<UpdateBrandCampaignDto>(jsonData);

            return View(brandCampaign); // View'a modeli gönder
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrandCampaign(UpdateBrandCampaignDto updateBrandCampaignDto)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMTE0NzksImV4cCI6MTc1MDAxMzI3OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjkxODA1MDMyNTYwNkVEODA2MjJDNkI3RUFFRUM2MTU3IiwiaWF0IjoxNzUwMDExNDc5LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.SMrD78AKJC2ZUHikq5joZDH5dApP8_mk5AuVTYnGEEVt3rOh-twBT7Z0mn3GAjKCGFNW9X-wg-7lsgqjtad36WNrqVbmjE2WwvcZo5fpIO6X3gwCytJ8suxF5OCLPqt7E3jCGZDWS2iAIOjJzEfxDy7iUSQga1VcrD-sUYOOHMR-nmof77DoVw0SEdhQtKKTufE13T7P9EhnV2K6H5EXfIfhsZc1BVvum7UQHy6FT09wDL0nhcqtv02XFZ2lcghDn3dcUtlyzrVW7HDCPJPMEgc6yBBBcEZ_B6HWuWa6TS6bxYY2EOmwQ6po12PgdXBgideg89WudxEjMET5dZ2frA";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(updateBrandCampaignDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7100/api/BrandCampaigns", content);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Güncelleme başarısız.");

            return RedirectToAction("Index", "BrandCampaign", new { area = "Admin" });
        }
    }
}
