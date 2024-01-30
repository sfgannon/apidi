using System.Text.Json;
using ApiDi.Classes;

public class BasicService : IBasicService
{
    private readonly HttpClient _client;
    private readonly IKey _keyService;
    public BasicService(HttpClient client, IKey keyService) {
        _client = client;
        _client.BaseAddress = new Uri("http://localhost:5121");
        _keyService = keyService;
    }
    public async Task<string> GetString() {
        return "okay";
    }

    public async Task<string> GetApi(){
        using HttpResponseMessage msg = await _client.GetAsync("/WeatherForecast");
        Console.Write(msg.Content.ReadAsStringAsync().ToString());
        return await msg.Content.ReadAsStringAsync();
    }

    public async Task<string> ApiCall(){
        string? TwelveDataKey = _keyService.GetTwelveData();
        string? AlphaVantageKey = _keyService.GetAlphaVantage();
        return string.Format("Key Values are {0} and {1}", TwelveDataKey, AlphaVantageKey);
    }

    public async Task<TimeSeries> GetSymbol(AlphaVantageOptions opts) {
        
        return new TimeSeries();
    }
}