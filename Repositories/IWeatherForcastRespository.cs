using WeatherWebApp.OpenWeatherModel;

namespace WeatherWebApp.Repositories
{
    public interface IWeatherForcastRespository
    {

        WeatherResponse GetForcast(string City);
    }
}
