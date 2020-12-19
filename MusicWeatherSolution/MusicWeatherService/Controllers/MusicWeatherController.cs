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
    [Produces("application/json")]
    [Route("api/musicweather")]
    [ApiController]
    public class MusicWeatherController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public MusicWeatherController(IHttpClientFactory clientFactory)
        {
            _clientFactory  = clientFactory;
        }

        /// <summary>
        /// Sugestão de música de acordo com a temperatura.
        /// </summary>
        /// <param name="cidade">Nome da cidade parâmetro opcional</param>
        /// <param name="lat">Latitude parâmetro opcional</param>
        /// <param name="lon">Longitude parâmetro opcional</param>
        /// <returns>Retorna a música sugerida</returns>
        /// <response code="200">Status retornado se tudo funcionar.</response>
        /// <response code="400">Retorno caso algum parâmetro esteja inválido</response>
        /// <response code="500">Retorno em caso de erro de falha geral</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

            try
            {
                //Simples como a vida deve ser
                TemperaturaMusicalService temperaturaMusicalService = new TemperaturaMusicalService(_clientFactory);
                return temperaturaMusicalService.SugerirMusica(parametro);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
