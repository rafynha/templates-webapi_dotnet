using component.template.api.domain;
using component.template.api.domain.Common;
using component.template.api.domain.Interfaces.Business;
using component.template.api.domain.Interfaces.Business.Common;

namespace component.template.api.business;

public class WeatherForecastBusiness : BaseBusiness, IWeatherForecastBusiness
{   
    public async Task<IEnumerable<WeatherForecastResponse>> GetAll()
    {
        
        string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecastResponse
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
    }    
}