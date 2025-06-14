using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Collections.Specialized.BitVector32;
using System.ComponentModel;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.CategoryDtos;
using System.Text;
using System.Net.Http.Headers;

namespace SwiftShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.SectionLink1 = "Anasayfa";
            ViewBag.SectionLink2 = "Kategoriler";
            ViewBag.SectionLink3 = "Kategori Listesi";
            ViewBag.SectionTitle = "Kategori İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Categories");

            if(!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoriesAsString = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            return View(categoriesAsString);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            //ViewBag.SectionLink1 = "Anasayfa";
            //ViewBag.SectionLink2 = "Kategoriler";
            //ViewBag.SectionLink3 = "Yeni Kategori";
            //ViewBag.SectionTitle = "Kategori Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //its not posting because of authorization
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjI0MzcsImV4cCI6MTc0OTkyNDIzNywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjQ5RDkzNTYxNzkxQzZDRDhFQzUzOTU3MkI3RkMwNEM0IiwiaWF0IjoxNzQ5OTIyNDM3LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.JT4066qxM1KH_d2ety48zXzD6vjP6z71X0778vI9BsntJZlNSOlPwUrxXFfqWUadPFSyK0HpK58QnaBr72VG7uEXS9ifHx-XA2bXas2RwpztMpHJ6hMUFbBwyQmcFEj2AMK1ZoDvW7YAa22DL0PC43FMaYfsxLXa51NBm3mVYF4n9peg717ecsULeNxYGqXWlJlJC-lXeg0F2jOrMT-VaFj457GGueZ4Mba_yIRO0ZzZV3viN_WlSCDYAVLoB1tjpxBCeg4DJ5EJRqxQjdQ-2jrz-CWtiOgQ2P7TMGdSogjk2x7l-qYHZ9fX1UdcC2NXNq_yVGPFWtlI3Ya5gmSTQg";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/Categories", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjI0MzcsImV4cCI6MTc0OTkyNDIzNywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjQ5RDkzNTYxNzkxQzZDRDhFQzUzOTU3MkI3RkMwNEM0IiwiaWF0IjoxNzQ5OTIyNDM3LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.JT4066qxM1KH_d2ety48zXzD6vjP6z71X0778vI9BsntJZlNSOlPwUrxXFfqWUadPFSyK0HpK58QnaBr72VG7uEXS9ifHx-XA2bXas2RwpztMpHJ6hMUFbBwyQmcFEj2AMK1ZoDvW7YAa22DL0PC43FMaYfsxLXa51NBm3mVYF4n9peg717ecsULeNxYGqXWlJlJC-lXeg0F2jOrMT-VaFj457GGueZ4Mba_yIRO0ZzZV3viN_WlSCDYAVLoB1tjpxBCeg4DJ5EJRqxQjdQ-2jrz-CWtiOgQ2P7TMGdSogjk2x7l-qYHZ9fX1UdcC2NXNq_yVGPFWtlI3Ya5gmSTQg";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/Categories?categoryId={id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("Silme işlemi başarısız oldu.");
            }

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjI0MzcsImV4cCI6MTc0OTkyNDIzNywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjQ5RDkzNTYxNzkxQzZDRDhFQzUzOTU3MkI3RkMwNEM0IiwiaWF0IjoxNzQ5OTIyNDM3LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.JT4066qxM1KH_d2ety48zXzD6vjP6z71X0778vI9BsntJZlNSOlPwUrxXFfqWUadPFSyK0HpK58QnaBr72VG7uEXS9ifHx-XA2bXas2RwpztMpHJ6hMUFbBwyQmcFEj2AMK1ZoDvW7YAa22DL0PC43FMaYfsxLXa51NBm3mVYF4n9peg717ecsULeNxYGqXWlJlJC-lXeg0F2jOrMT-VaFj457GGueZ4Mba_yIRO0ZzZV3viN_WlSCDYAVLoB1tjpxBCeg4DJ5EJRqxQjdQ-2jrz-CWtiOgQ2P7TMGdSogjk2x7l-qYHZ9fX1UdcC2NXNq_yVGPFWtlI3Ya5gmSTQg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync($"https://localhost:7100/api/Categories/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);

            return View(category); // View'a modeli gönder
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjI0MzcsImV4cCI6MTc0OTkyNDIzNywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjQ5RDkzNTYxNzkxQzZDRDhFQzUzOTU3MkI3RkMwNEM0IiwiaWF0IjoxNzQ5OTIyNDM3LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.JT4066qxM1KH_d2ety48zXzD6vjP6z71X0778vI9BsntJZlNSOlPwUrxXFfqWUadPFSyK0HpK58QnaBr72VG7uEXS9ifHx-XA2bXas2RwpztMpHJ6hMUFbBwyQmcFEj2AMK1ZoDvW7YAa22DL0PC43FMaYfsxLXa51NBm3mVYF4n9peg717ecsULeNxYGqXWlJlJC-lXeg0F2jOrMT-VaFj457GGueZ4Mba_yIRO0ZzZV3viN_WlSCDYAVLoB1tjpxBCeg4DJ5EJRqxQjdQ-2jrz-CWtiOgQ2P7TMGdSogjk2x7l-qYHZ9fX1UdcC2NXNq_yVGPFWtlI3Ya5gmSTQg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7100/api/Categories", content);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Güncelleme başarısız.");

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }


    }
}
