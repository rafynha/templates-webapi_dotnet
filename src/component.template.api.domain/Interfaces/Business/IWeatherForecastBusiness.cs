namespace component.template.api.domain.Interfaces.Business
{
    public interface IWeatherForecastBusiness
    {
        Task<IEnumerable<WeatherForecastResponse>> GetAll();
    }
}