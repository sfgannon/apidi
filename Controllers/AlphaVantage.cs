using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDi.Controllers;

[ApiController]
[Route("api/Controller/[action]")]
public class AlphaVantageController : ControllerBase
{
    private readonly string _baseUri = "https://www.alphavantage.co/query?function={0}&symbol=IBM&interval=5min&apikey=demo"
    private readonly HttpClient _client;
    public AlphaVantageController(HttpClient client) {
        _client = client;
    }
    public async Task<string> GetTS(string pFunction, string pSymbol, string pInterval) {
        string requestUri = string.Format(_baseUri, pFunction, pSymbol, pInterval);
        using HttpResponseMessage msg = await _client.GetAsync(requestUri);
        return JsonSerializer.Serialize(msg.Content.ReadAsStringAsync());
    }
}