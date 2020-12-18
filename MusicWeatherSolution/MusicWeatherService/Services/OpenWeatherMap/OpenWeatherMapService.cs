using MusicWeatherService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace MusicWeatherService.Services.OpenWeatherMap
{
    public class OpenWeatherMapService : ITemperaturaService
    {
        private string _key = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_KEY");
        private const string _units = "metric";
        private const string _namedClient = "OpenWeatherMap";

        [Inject]
        public IHttpClientFactory _clientFactory { get; set; }

        public OpenWeatherMapService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public double GetTemperaturaAtual(Parametro parametro)
        {
            string url = "";

            if (!parametro.cidade.Equals(""))
            {
                url = $"?q={parametro.cidade}&appid={_key}&units={_units}";
            } 
            else
            {
                url = $"?lat={parametro.geo.latitude}&lon={parametro.geo.longitude}&appid={_key}&units={_units}";
            }

            return GetTemperatura(url).GetAwaiter().GetResult();
        }

        public async Task<double> GetTemperatura(string uri)
        {
            var client = _clientFactory.CreateClient(_namedClient);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var data = await client.GetStringAsync(uri);

                var responseObj = JsonSerializer.Deserialize<OpenWeatherMapResponse>(data);

                return responseObj.main.temp;
            }
            else
            {
                throw new Exception("Falha ao tentar consultar a temperatura.");
            }
        }
    }
}
