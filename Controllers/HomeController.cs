using Microsoft.AspNetCore.Mvc;

namespace ApiDi.Controllers;

[ApiController]
[Route("/")]
public class TestController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public TestController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<string> GetTest()
    {
        _logger.Log(LogLevel.Information, String.Format("Root {0} {1}, ", HttpContext.Connection.RemoteIpAddress, DateTime.Now));
        return "Equities API";
    }
}
