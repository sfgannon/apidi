using Microsoft.AspNetCore.Mvc;

namespace ApiDi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IBasicService basic;
    public WeatherForecastController(IBasicService svc) {
        basic = svc;
    }
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // [root]/WeatherForecast/Get
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // [root]/WeatherForecast/SomeData
    [HttpGet(Name = "GetTest")]
    public Task<string> SomeData() {
        return basic.GetString();
    }

    [HttpGet(Name = "GetApi")]
    public Task<string> GetApi(){
        return basic.GetApi();
    }
}
