using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDi.Controllers;

[ApiController]
[Route("api/Controller/[action]")]
public class AlphaVantageController : ControllerBase
{
    private readonly string _apiKey;
    private readonly string _baseUri = "https://www.alphavantage.co/query?function={0}&symbol={1}&interval={2}&apikey={3}";
    private readonly HttpClient _client;
    public AlphaVantageController(HttpClient client, IKey keyService) {
        _client = client;
        _apiKey = keyService.GetAlphaVantage();
    }
    public async Task<string> GetTS(string pFunction, string pSymbol, string pInterval) {
        string requestUri = string.Format(_baseUri, pFunction, pSymbol, pInterval, _apiKey);
        using HttpResponseMessage msg = await _client.GetAsync(requestUri);
        return JsonSerializer.Serialize(msg.Content.ReadAsStringAsync());
    }
}