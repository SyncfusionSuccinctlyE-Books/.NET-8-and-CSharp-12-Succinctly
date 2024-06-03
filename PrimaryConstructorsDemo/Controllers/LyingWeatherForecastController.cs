using Microsoft.AspNetCore.Mvc;
using PrimaryConstructorsDemo.Services;

namespace PrimaryConstructorsDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class LyingWeatherForecastController(
    IRandomCityService randomCityService, 
    IRandomSummaryService randomSummaryService) : ControllerBase
{
    
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            CityName = randomCityService.GetRandomCity(),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = randomSummaryService.GetRandomSummary()
        })
        .ToArray();
    }
}


//[ApiController]
//[Route("[controller]")]
//public class LyingWeatherForecastController : ControllerBase
//{
//    private readonly IRandomCityService _randomCityService;
//    private readonly IRandomSummaryService _randomSummaryService;

//    public LyingWeatherForecastController(IRandomCityService randomCityService, IRandomSummaryService randomSummaryService)
//    {
//        _randomCityService = randomCityService;
//        _randomSummaryService = randomSummaryService;
//    }

//    [HttpGet(Name = "GetWeatherForecast")]
//    public IEnumerable<WeatherForecast> Get()
//    {
//        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//        {
//            CityName = _randomCityService.GetRandomCity(),
//            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            TemperatureC = Random.Shared.Next(-20, 55),
//            Summary = _randomSummaryService.GetRandomSummary()
//        })
//        .ToArray();
//    }
//}
