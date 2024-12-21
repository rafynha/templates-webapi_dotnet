using component.template.api.domain.Exceptions;
using component.template.api.domain.Filters;
using component.template.api.domain.Helpers;
using component.template.api.domain.Interfaces.Business;
using component.template.api.domain.Interfaces.Common;
using component.template.api.domain.Models.Common;
using component.template.api.domain.Models.External;
using Microsoft.AspNetCore.Mvc;

namespace component.template.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserBusiness _userBusiness;

        public UserController(ILogger<UserController> logger, IUserBusiness userBusiness)
        {
            this._logger = logger;
            this._userBusiness = userBusiness;
        }

        [HttpPost]
        //[ResponseFilterFactory]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IApiResponse<IEnumerable<CreateUserResponse>>))]
        public async Task<ActionResult> Create(CreateUserRequest request)
        {
            _logger.LogInformation($"Iniciando endpoint Put do controller {typeof(UserController)} --> Params: {Newtonsoft.Json.JsonConvert.SerializeObject(request)}");

            if (ModelState.IsValid)
                return Ok(await _userBusiness.Create(request));
            else
                throw new InvalidModelStateException($"ModelState do controller {typeof(UserController)} inválido! --> Params:  {Newtonsoft.Json.JsonConvert.SerializeObject(request)}");
        }

        // [HttpGet]
        // //[ResponseFilterFactory]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IApiResponse<IEnumerable<WeatherForecastResponse>>))]
        // public async Task<ActionResult> Get()
        // {
        //     _logger.LogInformation($"Iniciando endpoint Put do controller {typeof(WeatherForecastController)} --> Params: {string.Empty/*Newtonsoft.Json.JsonConvert.SerializeObject(request)*/}");

        //     if (ModelState.IsValid)
        //         return Ok(await _weatherForecastBusiness.GetAll());
        //     else
        //         throw new InvalidModelStateException($"ModelState do controller {typeof(WeatherForecastController)} inválido! --> Params:");
        // }
    }
}