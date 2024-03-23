using ApiDi.Classes;
using Microsoft.AspNetCore.Mvc;

namespace ApiDi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
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

    // [root]/api/WeatherForecast/Get
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

    // [root]/api/WeatherForecast/SomeData
    [HttpGet(Name = "GetTest")]
    public Task<string> SomeData() {
        return basic.GetString();
    }

    // [root]/api/WeatherForecast/GetApi
    [HttpGet(Name = "GetApi")]
    public Task<string> GetApi(){
        return basic.GetApi();
    }

    // [root]/api/WeatherForecast/ApiCall
    [HttpGet(Name = "ApiCall")]
    public Task<TimeSeries> ApiCall(string rSymbol = "", string rFunction = ""){
        if (!String.IsNullOrEmpty(rSymbol) && !String.IsNullOrEmpty(rFunction)) {
            AlphaVantageRequest req = new AlphaVantageRequest(rSymbol, rFunction);
            return basic.GetSymbol(req);
        } else {
            throw new ArgumentException("Arguments not specified");
        }
    }

    // [HttpGet(Name = "GetSymbol")]
    // public Task<TimeSeries> GetSymbol() {
    //     AlphaVantageOptions opts = new AlphaVantageOptions();
    //     return basic.GetSymbol(opts);
    // }
}
