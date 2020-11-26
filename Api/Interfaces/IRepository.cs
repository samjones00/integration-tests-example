using System.Collections.Generic;

namespace Api.Interfaces
{
    public interface IRepository
    {
        IList<WeatherForecast> Get();
    }
}
