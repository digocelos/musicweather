using MusicWeatherService.Models;
using MusicWeatherService.Services.Spotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicWeatherService.Services
{
    public class TemperaturaMusicalService : ITemperaturaMusicalService
    {

        private readonly IMusicaService _musicaService;
        private readonly ITemperaturaService _temperaturaService;

        public TemperaturaMusicalService(IMusicaService musicaService, ITemperaturaService temperaturaService)
        {
            _musicaService = musicaService;
            _temperaturaService = temperaturaService;
        }

        public Musica SugerirMusica(Parametro parametro)
        {
            //Pegamos a temperatura atual
            double temperatura = TemperaturaAtual(parametro);

            //De acordo com a temperatua pegamos agora o tipo de música que desejamos sugerir
            IMusicaTipo musicaTipo = GetMusicaTipoPorTemperatua(temperatura);

            //Agora utilizamos o serviço de músicas para sugerir uma musica baseado no tipo informado.
            string musica = MusicaSugerida(musicaTipo);

            return new Musica(musica);
        }

        private double TemperaturaAtual(Parametro parametro)
        {
            //Monta service responsável por buscar a temperatura
            return _temperaturaService.GetTemperaturaAtual(parametro);
        }

        private IMusicaTipo GetMusicaTipoPorTemperatua(double temperatura)
        {
            // Retorna o tipo de música de acordo com a temperatura encontrada
            if (temperatura > 30)
            {
                return new SpotifyFesta();
            }
            else if ((temperatura >= 15) & (temperatura <= 30))
            {
                return new SpotifyPop();
            }
            else if ((temperatura >= 10) & (temperatura < 15))
            {
                return new SpotifyRock();
            }
            else
            {
                return new SpotifyClassica();
            }
        }

        private string MusicaSugerida(IMusicaTipo musicaTipo)
        {
            return _musicaService.SugerirMusica(musicaTipo);
        }
    }
}
