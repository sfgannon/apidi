using System.Text.Json;

using ApiDi.Classes;

namespace ApiDi.Services {

    public class AVService : IAVService {
        private HttpClient _client;
        private string _baseUri;
        private string _apiKey;
        public AVService(HttpClient client, string baseUri, string apiKey) {
            _client = client;
            _baseUri = baseUri;
            _apiKey = apiKey;
        }
        public async Task<AVTS> GetTimeSeries(string pFunction = "TIME_SERIES_INTRADAY", string pSymbol = "QQQ", string pInterval = "5min") {
            using HttpResponseMessage msg = await _client.GetAsync(string.Format(_baseUri, pFunction, pSymbol, pInterval, _apiKey));
            string responseContent = await msg.Content.ReadAsStringAsync();
            AVTS? ret = JsonSerializer.Deserialize<AVTS>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return ret;
        }
        public async Task<AVTS> GetDaily(string pFunction = "TIME_SERIES_DAILY", string pSymbol = "QQQ", string pInterval = "5min") {
            using HttpResponseMessage msg = await _client.GetAsync(string.Format(_baseUri, pFunction, pSymbol, pInterval, _apiKey));
            string responseContent = await msg.Content.ReadAsStringAsync();
            AVTS? ret = JsonSerializer.Deserialize<AVTS>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return ret;
        }
    }
}