using component.template.api.domain;
using component.template.api.domain.Interfaces.Business;

namespace component.template.api.business;

public class WeatherForecastBusiness : IWeatherForecastBusiness
{
    public IEnumerable<WeatherForecastResponse> GetAll()
    {
        string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        return Enumerable.Range(1, 5).Select(index => new WeatherForecastResponse
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}