using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwiftShop.UIDtoLayer.CatalogDtos.FeatureSliderDtos;
using System.Net.Http.Headers;
using System.Text;

namespace SwiftShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/FeatureSliders");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var featureSlidersAsString = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

            //var activeSliders = featureSlidersAsString
            //    .Where(x => x.Status == true)
            //    .ToList();

            return View(featureSlidersAsString);
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            //its not posting because of authorization
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5ODk0ODQsImV4cCI6MTc0OTk5MTI4NCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjhGOEVFMEM2OEM3MzAxOUFFQjA2NjQzNjFENENEOTNBIiwiaWF0IjoxNzQ5OTg5NDg0LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.B-c7euvKTpPLjeT816D8nLn0fut1PVaPSgAnA1raO2o2npyAsYKfN2XQhCTkuSjaGcmy0L7gLBuZfoRIDjnlT1T4f7pfr6CpO18sQCHnTuVZHEVjd5R3xS47NuAsn9dZihqEKVrBWQynH6DEMO3HC_Bpnwb6ou1u2kGu1VOAs7892M-oEbESdFmLMNShmhpVs-Q24zf_MZyBhwTIOKX7k4zlbedJJEzL0HyLy7dt5c0wG8TdcxCvM6huk5TtIact1sJaMQE7C9XStDkvXIpk5-KHWqUN8HmO8jLEbFWNmb0nbndye5lD1Ip3pdiAQOfYRXbcHhVruR928ToZkkNeZw";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/FeatureSliders", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("İşlem başarısız oldu. Sunucudan olumlu yanıt alınamadı.");
            }

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5ODk0ODQsImV4cCI6MTc0OTk5MTI4NCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjhGOEVFMEM2OEM3MzAxOUFFQjA2NjQzNjFENENEOTNBIiwiaWF0IjoxNzQ5OTg5NDg0LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.B-c7euvKTpPLjeT816D8nLn0fut1PVaPSgAnA1raO2o2npyAsYKfN2XQhCTkuSjaGcmy0L7gLBuZfoRIDjnlT1T4f7pfr6CpO18sQCHnTuVZHEVjd5R3xS47NuAsn9dZihqEKVrBWQynH6DEMO3HC_Bpnwb6ou1u2kGu1VOAs7892M-oEbESdFmLMNShmhpVs-Q24zf_MZyBhwTIOKX7k4zlbedJJEzL0HyLy7dt5c0wG8TdcxCvM6huk5TtIact1sJaMQE7C9XStDkvXIpk5-KHWqUN8HmO8jLEbFWNmb0nbndye5lD1Ip3pdiAQOfYRXbcHhVruR928ToZkkNeZw";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/FeatureSliders?featureSliderId={id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return BadRequest("Silme işlemi başarısız oldu.");
            }

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5ODk0ODQsImV4cCI6MTc0OTk5MTI4NCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjhGOEVFMEM2OEM3MzAxOUFFQjA2NjQzNjFENENEOTNBIiwiaWF0IjoxNzQ5OTg5NDg0LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.B-c7euvKTpPLjeT816D8nLn0fut1PVaPSgAnA1raO2o2npyAsYKfN2XQhCTkuSjaGcmy0L7gLBuZfoRIDjnlT1T4f7pfr6CpO18sQCHnTuVZHEVjd5R3xS47NuAsn9dZihqEKVrBWQynH6DEMO3HC_Bpnwb6ou1u2kGu1VOAs7892M-oEbESdFmLMNShmhpVs-Q24zf_MZyBhwTIOKX7k4zlbedJJEzL0HyLy7dt5c0wG8TdcxCvM6huk5TtIact1sJaMQE7C9XStDkvXIpk5-KHWqUN8HmO8jLEbFWNmb0nbndye5lD1Ip3pdiAQOfYRXbcHhVruR928ToZkkNeZw";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync($"https://localhost:7100/api/FeatureSliders/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var featureSlider = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);

            return View(featureSlider); // View'a modeli gönder
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNGMDQ2MTMwMzg5MTlGOTgyM0IxOTI5QkZDODU2RkNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE3NDk5ODk0ODQsImV4cCI6MTc0OTk5MTI4NCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbIkNhcnRSZXNvdXJjZSIsIkNhdGFsb2dSZXNvdXJjZSIsIkRpc2NvdW50UmVzb3VyY2UiLCJPcmRlclJlc291cmNlIiwiU2hpcHBpbmdSZXNvdXJjZSIsImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS9yZXNvdXJjZXMiXSwiY2xpZW50X2lkIjoiQWRtaW5JZCIsImp0aSI6IjhGOEVFMEM2OEM3MzAxOUFFQjA2NjQzNjFENENEOTNBIiwiaWF0IjoxNzQ5OTg5NDg0LCJzY29wZSI6WyJDYXJ0RnVsbFBlcm1pc3Npb24iLCJDYXRhbG9nRnVsbFBlcm1pc3Npb24iLCJEaXNjb3VudEZ1bGxQZXJtaXNzaW9uIiwiSWRlbnRpdHlTZXJ2ZXJBcGkiLCJPcmRlckZ1bGxQZXJtaXNzaW9uIiwiU2hpcHBpbmdGdWxsUGVybWlzc2lvbiJdfQ.B-c7euvKTpPLjeT816D8nLn0fut1PVaPSgAnA1raO2o2npyAsYKfN2XQhCTkuSjaGcmy0L7gLBuZfoRIDjnlT1T4f7pfr6CpO18sQCHnTuVZHEVjd5R3xS47NuAsn9dZihqEKVrBWQynH6DEMO3HC_Bpnwb6ou1u2kGu1VOAs7892M-oEbESdFmLMNShmhpVs-Q24zf_MZyBhwTIOKX7k4zlbedJJEzL0HyLy7dt5c0wG8TdcxCvM6huk5TtIact1sJaMQE7C9XStDkvXIpk5-KHWqUN8HmO8jLEbFWNmb0nbndye5lD1Ip3pdiAQOfYRXbcHhVruR928ToZkkNeZw";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7100/api/FeatureSliders", content);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Güncelleme başarısız.");

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
