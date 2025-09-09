using AZ_AI_Vision_DenseCaption.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace AZ_AI_Vision_DenseCaption.Services
{
    public class VisionService : IVisionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly string _apiVersion;

        public VisionService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _endpoint = config["AzureVision:Endpoint"] ?? throw new ArgumentNullException("Endpoint");
            _apiVersion = config["AzureVision:ApiVersion"] ?? "";

            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config["AzureVision:Key"]);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> GetDenseCaptionsAsync(string imageUrl)
        {
            var uri = $"{_endpoint}computervision/imageanalysis:analyze" +
              $"?api-version={_apiVersion}&features=denseCaptions";

            var payload = new { url = imageUrl };
            var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
