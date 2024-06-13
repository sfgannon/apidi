using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using ApiDi.Classes;
using ApiDi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiDi.Controllers;

[ApiController]
[Route("api/Controller/[action]")]
public class AlphaVantageController : ControllerBase
{
    private readonly string? _apiKey;
    private readonly string _baseUri = "https://www.alphavantage.co/query?function={0}&symbol={1}&interval={2}&apikey={3}";
    private readonly HttpClient _client;
    private readonly IAVService _service;
    public AlphaVantageController(HttpClient client, IKey keyService, IAVService service) {
        _client = client;
        _apiKey = keyService.GetAlphaVantage();
        _service = service;
    }
    [HttpGet(Name = "GetTS")]
    public async Task<string> GetTS(string pFunction = "TIME_SERIES_INTRADAY", string pSymbol = "QQQ", string pInterval = "5min") {
        string requestUri = string.Format(_baseUri, pFunction, pSymbol, pInterval, _apiKey);
        using HttpResponseMessage msg = await _client.GetAsync(requestUri);
        // Serialize this into a TimeSeries, change return type
        string output = await msg.Content.ReadAsStringAsync();
        Console.WriteLine(output);
        return JsonSerializer.Serialize(output);
    }

    [HttpGet(Name="TimeSeries")]
    public async Task<AVTS?> GetTimeSeries(string pFunction = "TIME_SERIES_INTRADAY", string pSymbol = "QQQ", string pInterval = "30min") {
        return await _service.GetTimeSeries(pFunction, pSymbol, pInterval);
    }   

    [HttpGet(Name="Daily")]
    public async Task<AVTS?> GetDaily(string pFunction = "TIME_SERIES_DAILY", string pSymbol = "QQQ") {
        return await _service.GetDaily(pFunction, pSymbol);
    }   
}