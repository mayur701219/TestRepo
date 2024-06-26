using Microsoft.AspNetCore.Mvc;
using System.Text;

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


        //[HttpGet("{passportNo}")]
        //public async Task<IActionResult> GetPassportData(string passportNo)
        //{
        //    if (passportNo != "Test")
        //    {
        //        return BadRequest(new { message = "Invalid passport number" });
        //    }
        //    // Simulate data retrieval, replace with actual data fetching logic
        //    var passportData = new PassportResponse
        //    {
        //        PresentNationality = "US",
        //        Dob = "1990-01-01",
        //        BirthCountry = "USA",
        //        IssueDate = "2022-01-01",
        //        ExpireDate = "2032-01-01",
        //        BirthPlace = "New York",
        //        Fname = "John",
        //        Lname = "Doe",
        //        IssuePlace = "Washington",
        //        FatherName = "Michael Doe",
        //        MotherName = "Emily Doe",
        //        Gender = "2",

        //        ComingFrom = "India",
        //        Language = "Hindi",
        //        Religion = "Hindu"
        //    };

        //    // Simulate delay
        //    await Task.Delay(1000);

        //    return Ok(passportData);
        //}

        //[HttpGet("getJsFile")]
        //public async Task<IActionResult> GetJsFile()
        //{
        //    // Example script content
        //    var scriptContent = @"
        //    document.addEventListener('DOMContentLoaded', function () {
        //        const submitButton = document.getElementById('submitButton');
        //        submitButton.addEventListener('click', function () {
        //            const passportNo = document.getElementById('passportInput').value.trim();
        //            const resultDiv = document.getElementById('result');
                    
        //            resultDiv.innerText = '';
        //            resultDiv.classList.remove('error');
        
        //            if (passportNo === '') {
        //                resultDiv.innerText = 'Error: Passport number is required';
        //                resultDiv.classList.add('error');
        //            } else {
        //                fetchDummyPassportData(passportNo);
        //            }
        //        });
        //    });

        //    function fetchDummyPassportData(passportNo) {
        //        setTimeout(() => {
        //            const simulatedApiResponse = {
        //                dob: '01-02-1999',
        //                birthCountry: 'India',
        //                dateofissue: '20-02-2022',
        //                expireDate: '20-02-2022',
        //                birthPlace: 'Mumbai',
        //                fname: 'AZAD',
        //                lname: 'RATHORE',
        //                fathername: 'SINGH',
        //                mothername: 'KOKILA',
        //                passportissueplace: '',
        //                gender: '1',
        //                presentNationality: '',
        //                adhaarno: ''
        //            };
        
        //            const resultDiv = document.getElementById('result');
        //            resultDiv.classList.remove('error');
        
        //            chrome.tabs.query({ active: true, currentWindow: true }, (tabs) => {
        //                const handleResponse = (response) => {
        //                    if (chrome.runtime.lastError) {
        //                        resultDiv.innerText = `Error: ${chrome.runtime.lastError.message}`;
        //                        resultDiv.classList.add('error');
        //                    } else if (!response) {
        //                        resultDiv.innerText = 'Error: No response received';
        //                        resultDiv.classList.add('error');
        //                    } else if (response.status === 'success') {
        //                        console.log('Field updated successfully');
        //                    } else {
        //                        resultDiv.innerText = `Error: ${response.message}`;
        //                        resultDiv.classList.add('error');
        //                    }
        //                };
        
        //                const sendMessage = (action, data) => {
        //                    chrome.tabs.sendMessage(tabs[0].id, { action, data }, handleResponse);
        //                };
        
        //                sendMessage('presentNationality', { presentNationality: simulatedApiResponse.presentNationality });
        //                sendMessage('dob', { dob: simulatedApiResponse.dob });
        //                sendMessage('birthCountry', { birthCountry: simulatedApiResponse.birthCountry });
        //                sendMessage('dateofissue', { dateofissue: simulatedApiResponse.dateofissue });
        //                sendMessage('expireDate', { expireDate: simulatedApiResponse.expireDate });
        //                sendMessage('birthPlace', { birthPlace: simulatedApiResponse.birthPlace });
        //                sendMessage('fname', { fname: simulatedApiResponse.fname });
        //                sendMessage('lname', { lname: simulatedApiResponse.lname });
        //                sendMessage('passportissueplace', { passportissueplace: simulatedApiResponse.passportissueplace });
        //                sendMessage('fathername', { fathername: simulatedApiResponse.fathername });
        //                sendMessage('mothername', { mothername: simulatedApiResponse.mothername });
        //                sendMessage('gender', { gender: simulatedApiResponse.gender });
        //            });
        //        }, 1000);
        //    }
        //";

        //    // Generate a byte array from the script content
        //    var scriptBytes = Encoding.UTF8.GetBytes(scriptContent);

        //    // Return the script as a file
        //    var memoryStream = new MemoryStream(scriptBytes);
        //    return File(memoryStream, "application/javascript", "script.js");
        //}
    }
}