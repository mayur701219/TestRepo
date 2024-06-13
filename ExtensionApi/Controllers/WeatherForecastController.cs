using Microsoft.AspNetCore.Mvc;

namespace ExtensionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

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


        [HttpGet("{passportNo}")]
        public async Task<IActionResult> GetPassportData(string passportNo)
        {
            if (passportNo != "Test")
            {
                return BadRequest(new { message = "Invalid passport number" });
            }
            // Simulate data retrieval, replace with actual data fetching logic
            var passportData = new PassportResponse
            {
                PresentNationality = "US",
                Dob = "1990-01-01",
                BirthCountry = "USA",
                IssueDate = "2022-01-01",
                ExpireDate = "2032-01-01",
                BirthPlace = "New York",
                Fname = "John",
                Lname = "Doe",
                IssuePlace = "Washington",
                FatherName = "Michael Doe",
                MotherName = "Emily Doe",
                Gender = "2",

                ComingFrom = "India",
                Language = "Hindi",
                Religion = "Hindu"
            };

            // Simulate delay
            await Task.Delay(1000);

            return Ok(passportData);
        }
    }
}