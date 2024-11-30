using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace component.template.api.domain.Interfaces.Business
{
    public interface IWeatherForecastBusiness
    {
        IEnumerable<WeatherForecastResponse> GetAll();
    }
}