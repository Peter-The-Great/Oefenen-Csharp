using Microsoft.AspNetCore.Mvc;
using asp.Models;
namespace asp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private static readonly List<WeatherForecast> Forecasts = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Forecasts;
    }

    [HttpGet("{id}")]
    public ActionResult<WeatherForecast> Get(int id)
    {
        var forecast = Forecasts.FirstOrDefault(f => f.Id == id);
        if (forecast == null)
        {
            return NotFound();
        }
        return forecast;
    }

    [HttpPost]
    public ActionResult<WeatherForecast> Post([FromBody] WeatherForecast forecast)
    {
        forecast.Id = Forecasts.Count > 0 ? Forecasts.Max(f => f.Id) + 1 : 1;
        Forecasts.Add(forecast);
        return CreatedAtAction(nameof(Get), new { id = forecast.Id }, forecast);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] WeatherForecast updatedForecast)
    {
        var forecast = Forecasts.FirstOrDefault(f => f.Id == id);
        if (forecast == null)
        {
            return NotFound();
        }

        forecast.Date = updatedForecast.Date;
        forecast.TemperatureC = updatedForecast.TemperatureC;
        forecast.Summary = updatedForecast.Summary;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var forecast = Forecasts.FirstOrDefault(f => f.Id == id);
        if (forecast == null)
        {
            return NotFound();
        }

        Forecasts.Remove(forecast);
        return NoContent();
    }
}
