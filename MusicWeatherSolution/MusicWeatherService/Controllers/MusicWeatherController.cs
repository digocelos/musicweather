using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicWeatherService.Models;
using MusicWeatherService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace MusicWeatherService.Controllers    
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicWeatherController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private IWeatherService _weatherService;

        public MusicWeatherController(IHttpClientFactory clientFactory)
        {
            _clientFactory  = clientFactory;
            _weatherService = WeatherServiceFactory.GetInstance(WeatherEngine.OpenWeatherMap, _clientFactory);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Musica> Get( [FromQuery] string cidade = "", [FromQuery] double lat = 91, double lon = 181)
        {
            var parametro = new Parametro { 
                cidade = cidade, 
                geo = new GeoPoint { 
                    latitude = lat,
                    longitude = lon
                } 
            };

            if (!parametro.valida())
            {
                return BadRequest();
            }
                        
            var temp = _weatherService.GetTemperaturaAtual(parametro);
            return Ok(new Musica($"Teste temp: {temp}"));
        }
    }
}
