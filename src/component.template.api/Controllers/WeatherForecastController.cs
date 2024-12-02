using component.template.api.domain;
using component.template.api.domain.Exceptions;
using component.template.api.domain.Factory;
using component.template.api.domain.Interfaces.Business;
using component.template.api.domain.Interfaces.Common;
using component.template.api.domain.Models.Common;
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
            this._logger = logger;
        }

        [HttpGet]
        //[ResponseFilterFactory]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IApiResponse<IEnumerable<WeatherForecastResponse>>))]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation($"Iniciando endpoint Put do controller {typeof(WeatherForecastController)} --> Params: {string.Empty/*Newtonsoft.Json.JsonConvert.SerializeObject(request)*/}");

            if (ModelState.IsValid)
                return Ok(await _weatherForecastBusiness.GetAll());
            else
                throw new InvalidModelStateException($"ModelState do controller {typeof(WeatherForecastController)} inválido! --> Params:");
        }
    }
}