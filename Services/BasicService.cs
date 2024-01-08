using System.Text.Json;

public class BasicService : IBasicService
{
    private readonly HttpClient _client;
    public BasicService(HttpClient client) {
        _client = client;
        _client.BaseAddress = new Uri("http://localhost:5121");
    }
    public async Task<string> GetString() {
        return "Okay";
    }

    public async Task<string> GetApi(){
        using HttpResponseMessage msg = await _client.GetAsync("/WeatherForecast");
        Console.Write(msg.Content.ReadAsStringAsync().ToString());
        return await msg.Content.ReadAsStringAsync();
    }
}