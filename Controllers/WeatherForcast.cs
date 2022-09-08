using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherWebApp.Models;
using WeatherWebApp.OpenWeatherModel;
using WeatherWebApp.Repositories;

namespace WeatherWebApp.Controllers
{
    public class WeatherForcast : Controller
    {
        private readonly ILogger<WeatherForcast> _logger;
        private readonly IWeatherForcastRespository _w  ;

        public WeatherForcast(ILogger<WeatherForcast> logger ,IWeatherForcastRespository w )
        {
            _logger = logger;
            _w = w;
        }

        [HttpGet]
        public IActionResult SearchByCity()
        {

            var Model = new SearchByCity();
            return View(Model);
        }

        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {

            if (ModelState.IsValid)
            {


                return RedirectToAction("City", "WeatherForcast", new
                {
                    City = model.CityName
                });


            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string City)
        {
            WeatherResponse weather = _w.GetForcast(City);
            City Model = new City();
            if(weather != null)
            {
                Model.Name=weather.Name;
                Model.Temprature = weather.Main.Temp;
                Model.Humidity = weather.Main.Humidity;
                Model.Pressure = weather.Main.Pressure;
                Model.Weather = weather.Weather[0].Main;
                Model.Wind = weather.Wind.Speed;



                
            }
            return  View(Model);
        }

    }
}