using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{

    ///We need to place class names above Controller class for 2 reasons
    ///To tell .Net to treat this controller as an API
    ///And it tells .Net what URL to place the API on, When it's a contoller it is supposed to be the name of the controller
    ///IE this controllers name is WeatherForcast

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //This is a placeholder for a database
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        //Above each action we want to tell the API what type of endpoint we're using 
        //along with the name of the endpoint.
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}