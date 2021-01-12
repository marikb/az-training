using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;

namespace AsafAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        
        public IEnumerable<WeatherForecast> GetAllPeople()
        {
            return people;
        }
        [HttpPost]
        public IEnumerable<WeatherForecast> Post()
        {
            
        }
    }
}
