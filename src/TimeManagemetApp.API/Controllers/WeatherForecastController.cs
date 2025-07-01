using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeManagemetApp.Models.Models;

namespace TimeManagemetApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly BusinessLogic.Services.WeatherForecastService _service;

        public WeatherForecastController()
        {
            _service = new BusinessLogic.Services.WeatherForecastService();
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            return _service.GetForecast();
        }
    }
}
