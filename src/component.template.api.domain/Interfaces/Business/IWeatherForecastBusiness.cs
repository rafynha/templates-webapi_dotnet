using component.template.api.domain.Interfaces.Business.Common;

namespace component.template.api.domain.Interfaces.Business
{
    public interface IWeatherForecastBusiness : IBusinessServices
    {
        Task<IEnumerable<WeatherForecastResponse>> GetAll();
    }
}