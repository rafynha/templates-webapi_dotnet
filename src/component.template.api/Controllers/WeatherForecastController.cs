using component.template.api.domain;
using component.template.api.domain.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace component.template.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastBusiness _weatherForecastBusiness;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastBusiness weatherForecastBusiness)
        {
            this._weatherForecastBusiness = weatherForecastBusiness;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse<WeatherForecastResponse>))]
        public IEnumerable<WeatherForecastResponse> Get()
        {
            return _weatherForecastBusiness.GetAll();
        }
    }
}