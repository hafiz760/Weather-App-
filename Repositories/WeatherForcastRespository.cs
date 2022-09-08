using RestSharp;
using WeatherWebApp.OpenWeatherModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherWebApp.Configuration;

namespace WeatherWebApp.Repositories
{
    public class WeatherForcastRespository : IWeatherForcastRespository
    {
        public WeatherResponse GetForcast(string City)
        {
            string App_Id = Value.App_Id;
            var Client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={City}&appid={App_Id}");
            var req = new RestRequest(Method.GET);
            var response = Client.Execute(req) as RestResponse;
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content?.ToObject<WeatherResponse>();
            }
            else
            {
                return null;
            }

        }
    }
}
