using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.SpecialOfferDtos;
using System.Net.Http.Headers;
using System.Text;

namespace SwiftShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/SpecialOffers");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var specialOffersAsString = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);

            return View(specialOffersAsString);
        }

        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            //its not posting because of authorization
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMDE0MzEsImV4cCI6MTc1MDAwMzIzMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkE2MkQ0RjEzMTY3NEU1OUEwQjYxMjg0RkIxNDJDOTkzIiwiaWF0IjoxNzUwMDAxNDMxLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.p-wZ7f-MzymZdE4Ov5RQRPVWp497yr2YrjR-i1LLMtohtnZyYn_pPfxvOxbWao7JdoP4eXwhKxFCHgachi7L3uzhmgzRqWJTxJkgxcqHEdZYvW2ZbEVajnpLAJ-ALaiCo4JUOSQyDgEIY1MzLrA48SOYAJHmG0QDB6Zs0QMveA8T3bJof-FO1CJIXiZF1PfenqmdX7k33wBUmogZ0SsNg-mRqOCFiKLtXrVtPCOqWZU6xMHdgsbVf4pymhPsKo2pDS0k9S4nbMr1oQhw8Z5IRtI6nwApL6qBLXTr8ceLmjPwTsyPZpXtvekbG3FcJ4Iiv2B7A29OL8-gvevWS6coDg";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/SpecialOffers", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMDE0MzEsImV4cCI6MTc1MDAwMzIzMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkE2MkQ0RjEzMTY3NEU1OUEwQjYxMjg0RkIxNDJDOTkzIiwiaWF0IjoxNzUwMDAxNDMxLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.p-wZ7f-MzymZdE4Ov5RQRPVWp497yr2YrjR-i1LLMtohtnZyYn_pPfxvOxbWao7JdoP4eXwhKxFCHgachi7L3uzhmgzRqWJTxJkgxcqHEdZYvW2ZbEVajnpLAJ-ALaiCo4JUOSQyDgEIY1MzLrA48SOYAJHmG0QDB6Zs0QMveA8T3bJof-FO1CJIXiZF1PfenqmdX7k33wBUmogZ0SsNg-mRqOCFiKLtXrVtPCOqWZU6xMHdgsbVf4pymhPsKo2pDS0k9S4nbMr1oQhw8Z5IRtI6nwApL6qBLXTr8ceLmjPwTsyPZpXtvekbG3FcJ4Iiv2B7A29OL8-gvevWS6coDg";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/SpecialOffers?specialOfferId={id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("Silme işlemi başarısız oldu.");
            }

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMDE0MzEsImV4cCI6MTc1MDAwMzIzMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkE2MkQ0RjEzMTY3NEU1OUEwQjYxMjg0RkIxNDJDOTkzIiwiaWF0IjoxNzUwMDAxNDMxLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.p-wZ7f-MzymZdE4Ov5RQRPVWp497yr2YrjR-i1LLMtohtnZyYn_pPfxvOxbWao7JdoP4eXwhKxFCHgachi7L3uzhmgzRqWJTxJkgxcqHEdZYvW2ZbEVajnpLAJ-ALaiCo4JUOSQyDgEIY1MzLrA48SOYAJHmG0QDB6Zs0QMveA8T3bJof-FO1CJIXiZF1PfenqmdX7k33wBUmogZ0SsNg-mRqOCFiKLtXrVtPCOqWZU6xMHdgsbVf4pymhPsKo2pDS0k9S4nbMr1oQhw8Z5IRtI6nwApL6qBLXTr8ceLmjPwTsyPZpXtvekbG3FcJ4Iiv2B7A29OL8-gvevWS6coDg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync($"https://localhost:7100/api/SpecialOffers/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var specialOffer = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);

            return View(specialOffer); // View'a modeli gönder
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NTAwMDE0MzEsImV4cCI6MTc1MDAwMzIzMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IkE2MkQ0RjEzMTY3NEU1OUEwQjYxMjg0RkIxNDJDOTkzIiwiaWF0IjoxNzUwMDAxNDMxLCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.p-wZ7f-MzymZdE4Ov5RQRPVWp497yr2YrjR-i1LLMtohtnZyYn_pPfxvOxbWao7JdoP4eXwhKxFCHgachi7L3uzhmgzRqWJTxJkgxcqHEdZYvW2ZbEVajnpLAJ-ALaiCo4JUOSQyDgEIY1MzLrA48SOYAJHmG0QDB6Zs0QMveA8T3bJof-FO1CJIXiZF1PfenqmdX7k33wBUmogZ0SsNg-mRqOCFiKLtXrVtPCOqWZU6xMHdgsbVf4pymhPsKo2pDS0k9S4nbMr1oQhw8Z5IRtI6nwApL6qBLXTr8ceLmjPwTsyPZpXtvekbG3FcJ4Iiv2B7A29OL8-gvevWS6coDg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7100/api/SpecialOffers", content);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Güncelleme başarısız.");

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
