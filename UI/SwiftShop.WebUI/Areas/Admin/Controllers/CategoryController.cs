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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //its not posting because of authorization
            var client = _httpClientFactory.CreateClient();

            //var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjgzNTcsImV4cCI6MTc0OTkzMDE1NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkY4RjQ1RDI5MzJEOERGNjAwNzAyNEE2RURCRDQxNEI4IiwiaWF0IjoxNzQ5OTI4MzU2LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.CNLMHplkvb7PeeJ2gzgnH962Qk0Sdm4ybb4_4kTB47pBPvX2azm2vWkNiE72qBwLynirIQvp_Xw0D7-UsqaFZ8pu6D4wT6a2r0mNCuADLlbtps5Zgols0T5MzYjxtVEos13UpFSIF2i5RgatUufzjliIrEZP6zriZ1cNRY2sppjZD6cJKlinqQ-IDBmgwTL1NIbjjc7Fzl0zgiZR8BQtBbFVGCMgHbjoBSbJnQ2gqGe0-I3WtBYxqj7K1hXqaM0g8QFRcWCQV377-f9TmB05qEZHaAjEorBIKVQABASS3b9bwaSSHHGXkEzPUQPHyILmF8C_p8T-I3z_2uUmvM54wg";

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
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

            //var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjgzNTcsImV4cCI6MTc0OTkzMDE1NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkY4RjQ1RDI5MzJEOERGNjAwNzAyNEE2RURCRDQxNEI4IiwiaWF0IjoxNzQ5OTI4MzU2LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.CNLMHplkvb7PeeJ2gzgnH962Qk0Sdm4ybb4_4kTB47pBPvX2azm2vWkNiE72qBwLynirIQvp_Xw0D7-UsqaFZ8pu6D4wT6a2r0mNCuADLlbtps5Zgols0T5MzYjxtVEos13UpFSIF2i5RgatUufzjliIrEZP6zriZ1cNRY2sppjZD6cJKlinqQ-IDBmgwTL1NIbjjc7Fzl0zgiZR8BQtBbFVGCMgHbjoBSbJnQ2gqGe0-I3WtBYxqj7K1hXqaM0g8QFRcWCQV377-f9TmB05qEZHaAjEorBIKVQABASS3b9bwaSSHHGXkEzPUQPHyILmF8C_p8T-I3z_2uUmvM54wg";

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

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
            //var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjgzNTcsImV4cCI6MTc0OTkzMDE1NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkY4RjQ1RDI5MzJEOERGNjAwNzAyNEE2RURCRDQxNEI4IiwiaWF0IjoxNzQ5OTI4MzU2LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.CNLMHplkvb7PeeJ2gzgnH962Qk0Sdm4ybb4_4kTB47pBPvX2azm2vWkNiE72qBwLynirIQvp_Xw0D7-UsqaFZ8pu6D4wT6a2r0mNCuADLlbtps5Zgols0T5MzYjxtVEos13UpFSIF2i5RgatUufzjliIrEZP6zriZ1cNRY2sppjZD6cJKlinqQ-IDBmgwTL1NIbjjc7Fzl0zgiZR8BQtBbFVGCMgHbjoBSbJnQ2gqGe0-I3WtBYxqj7K1hXqaM0g8QFRcWCQV377-f9TmB05qEZHaAjEorBIKVQABASS3b9bwaSSHHGXkEzPUQPHyILmF8C_p8T-I3z_2uUmvM54wg";
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

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
            //var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5MjgzNTcsImV4cCI6MTc0OTkzMDE1NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkY4RjQ1RDI5MzJEOERGNjAwNzAyNEE2RURCRDQxNEI4IiwiaWF0IjoxNzQ5OTI4MzU2LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.CNLMHplkvb7PeeJ2gzgnH962Qk0Sdm4ybb4_4kTB47pBPvX2azm2vWkNiE72qBwLynirIQvp_Xw0D7-UsqaFZ8pu6D4wT6a2r0mNCuADLlbtps5Zgols0T5MzYjxtVEos13UpFSIF2i5RgatUufzjliIrEZP6zriZ1cNRY2sppjZD6cJKlinqQ-IDBmgwTL1NIbjjc7Fzl0zgiZR8BQtBbFVGCMgHbjoBSbJnQ2gqGe0-I3WtBYxqj7K1hXqaM0g8QFRcWCQV377-f9TmB05qEZHaAjEorBIKVQABASS3b9bwaSSHHGXkEzPUQPHyILmF8C_p8T-I3z_2uUmvM54wg";
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7100/api/Categories", content);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Güncelleme başarısız.");

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }


    }
}
