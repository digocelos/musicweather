using MusicWeatherService.Models;
using MusicWeatherService.Services.OpenWeatherMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicWeatherService.Services
{

    public enum WeatherEngine
    {
        OpenWeatherMap
    }

    //Contrato para obter a temperatura atual baseado nos parâmetros
    interface ITemperaturaService
    {
        double GetTemperaturaAtual(Parametro parametro);
    }

    class TemperaturaServiceFactory
    {
        public static ITemperaturaService GetInstance(WeatherEngine engine, IHttpClientFactory clientFactory)
        {
            switch(engine)
            {
                case WeatherEngine.OpenWeatherMap:
                {
                    return new OpenWeatherMapService(clientFactory);                     
                }
                default: return null;
            }
        }
    }
}
