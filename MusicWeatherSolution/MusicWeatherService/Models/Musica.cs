using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService.Models
{
    public class Musica
    {
        public string musicaSugerida { get; }

        public Musica(string musica)
        {
            musicaSugerida = musica;
        }
    }
}
